using System;
using System.Collections;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    /// <summary>
    /// Search is only possible via item id or item title.<para/>
    /// <para/>
    /// Current missing core features:<para/>
    /// # Function to list all items from the last 1,3,6,12 month<para/>
    /// # Function to list all item which have been last edited the last 1,3,6,12 month
    /// # Optional: Search by tags (only primary tags)
    /// </summary>
    public partial class SearchWindow : Form
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.exit();
        }

        public void resetSearchWindow()
        {
            string sql = "SELECT main.id,category_name,"
                        + "manufacturer_name,user_name FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN manufacturer ON main.manufacturer = manufacturer.id "
                        + "INNER JOIN user ON main.user = user.id LIMIT " + getMaxResultsInput() + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["user_name"],
                    (string)reader["category_name"], (string)reader["manufacturer_name"]);
            }
            reader.Close();

            resetGUIObject("category", comboBox_category);
            resetGUIObject("subcategory", comboBox_subcategory);
            resetGUIObject("manufacturer", comboBox_manufacturer);
            resetGUIObject("user", comboBox_user);
            resetGUIObject("status", comboBox_status);

            comboBox_sortBy.Items.Add("");
            comboBox_sortBy.Items.Add("id");
            comboBox_sortBy.Items.Add("title");
            comboBox_sortBy.Items.Add("category");
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            int itemID = -1;

            if (int.TryParse(textBox_search.Text, out itemID))
            {
                Hide();
                ClientMain.editorWindow.resetEditor();
                ClientMain.editorWindow.openExistingItem(itemID);
                ClientMain.editorWindow.Show();
            }
            else
            {
                executeSearch();
            }
        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                executeSearch();
                e.Handled = true;
            }
        }

        private void searchDataView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int databaseRecordId = (int)searchDataView.Rows[e.RowIndex].Cells[0].Value;

            Hide();
            ClientMain.editorWindow.resetEditor();
            ClientMain.editorWindow.openExistingItem(databaseRecordId);
            ClientMain.editorWindow.Show();
        }

        private void button_editor_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.editorWindow.resetEditor();
            ClientMain.editorWindow.Show();
        }

        public void executeSearch()
        {
            string text = this.textBox_search.Text;
            String sql;
            int tempItemID;
            bool insertFilter = false;

            sql = "SELECT main.id,category_name,"
                        + "manufacturer_name,user_name FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN manufacturer ON main.manufacturer = manufacturer.id "
                        + "INNER JOIN user ON main.user = user.id "
                        + "WHERE";

            if (int.TryParse(textBox_search.Text, out tempItemID))
            {
                sql = sql + " main.id = " + text;
                insertFilter = true;
            }
            else if (textBox_search.Text != "")
            {
                sql = sql + " main.title LIKE '%" + text + "%'";
                insertFilter = true;
            }

            sql = sql + getFilterSQLData("category", comboBox_category, insertFilter, out insertFilter)
                      + getFilterSQLData("subcategory", comboBox_subcategory, insertFilter, out insertFilter)
                      + getFilterSQLData("user", comboBox_user, insertFilter, out insertFilter)
                      + getFilterSQLData("manufacturer", comboBox_manufacturer, insertFilter, out insertFilter)
                      + getFilterSQLData("status", comboBox_status, insertFilter, out insertFilter);

            if (comboBox_sortBy.Text != "")
            {
                if (checkBox_sortDescending.Checked)
                {
                    sql = sql + " ORDER BY main." + comboBox_sortBy.Text + " ASC";
                }
                else
                {
                    sql = sql + " ORDER BY main." + comboBox_sortBy.Text + " DESC";
                }
            }

            sql = sql + " LIMIT " + getMaxResultsInput() + " ;";

            if (sql.Contains("WHERE ORDER BY") || sql.Contains("WHERE LIMIT"))
            {
                sql = sql.Replace(" WHERE", "");
            }

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            Console.WriteLine(sql);

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["user_name"],
                    (string)reader["category_name"], (string)reader["manufacturer_name"]);
            }
            reader.Close();
        }

        private ArrayList adjustSearchResultsByCreation(ArrayList searchResults, string creationFilter)
        {
            int maxTimeDiff;
            switch(creationFilter)
            {
                case "1 month ago":
                    maxTimeDiff = 1;
                    break;
                case "3 months ago":
                    maxTimeDiff = 3;
                    break;
                case "6 months ago":
                    maxTimeDiff = 6;
                    break;
                default:
                    maxTimeDiff = 1;
                    break;
            }

            foreach (int id in searchResults) {
                string sql = "SELECT date FROM main WHERE id = " + id;

                SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string date = (string)reader["date"];
                    string[] dateSplite = date.Split(new Char[] { '-' });

                    DateTime creation = new DateTime(int.Parse("20" + dateSplite[0]), int.Parse(dateSplite[1]), int.Parse(dateSplite[2]));
                    TimeSpan diff = DateTime.Today - creation;
                    int months = (int)((double)diff.Days / 30.436875); //30.436875 durchschnittliche Monatslänge

                    if(months > maxTimeDiff)
                    {
                        searchResults.Remove(id);
                    }
                }
                reader.Close();
            }

            return searchResults;
        }

        private string getFilterSQLData(string type, ComboBox reference, bool filterBefore, out bool success)
        {
            if (reference.Text != "")
            {
                int id;
                success = getSQLContentID(reference.Text, type, out id);

                if (success)
                {
                    if (filterBefore)
                    {
                        return " AND main." + type + " = " + id;
                    }
                    else
                    {
                        return " main." + type + " = " + id;
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                success = false;
                return "";
            }
        }

        private bool getSQLContentID(string reference, string type, out int id)
        {
            id = -1;
            string sql = "SELECT id FROM " + type
                        + " WHERE " + type + "_name = '" + reference + "' ;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                id = (int)reader["id"];
            }
            reader.Close();

            return id != -1 ? true : false;
        }

        private int getMaxResultsInput()
        {
            int limit;
            if (int.TryParse(textBox_maxResults.Text, out limit))
            {
                return limit;
            }
            else
            {
                return 30; //um nicht zu viele Objekte in die Liste zu laden
            }
        }

        private void resetGUIObject(String table, ComboBox reference)
        {
            string sql = "SELECT " + table + "_name FROM " + table + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reference.Items.Clear();
            reference.Items.Add("");
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reference.Items.Add((string)reader[table + "_name"]);
            }
            reader.Close();
        }
    }
}
