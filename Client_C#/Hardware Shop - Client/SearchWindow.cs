using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    /// <summary>
    /// Search is only possible via item id or item title.<para/>
    /// <para/>
    /// TODO:<para/>
    /// # Optional: Search by tags (only primary tags)
    /// # Cleanup code
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

            comboBox_date.SelectedText = "";
            comboBox_edit.SelectedText = "";

            comboBox_sortBy.SelectedText = "";
            checkBox_sortDescending.CheckState = CheckState.Unchecked;

            textBox_maxResults.Text = "";
            textBox_search.Text = "";
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
                        + "manufacturer_name,user_name,date FROM main "
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

            Dictionary<int, ArrayList> searchResults = new Dictionary<int, ArrayList>();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ArrayList data = new ArrayList();
                data.Add(reader["id"]);
                data.Add(reader["user_name"]);
                data.Add(reader["category_name"]);
                data.Add(reader["manufacturer_name"]);
                data.Add(reader["date"]);

                searchResults.Add((int)data[0], data);
            }
            reader.Close();

            searchResults = adjustSearchResultsByDate(searchResults, comboBox_date.Text);
            searchResults = adjustSearchResultsByDate(searchResults, comboBox_edit.Text);
            searchDataView.Rows.Clear();

            List<int> keyList = new List<int>(searchResults.Keys);
            for (int i = 0; i <= getMaxResultsInput() && i < keyList.Count; i++)
            {
                ArrayList data = searchResults[keyList[i]];
                searchDataView.Rows.Add(data[0], data[1], data[2], data[3]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchResults">Dictionary which hold structure: id, user_name, category_name, manufacture_name, date</param>
        /// <param name="dateFilter">Reference which date filter have been selected</param>
        /// <returns></returns>
        private Dictionary<int, ArrayList> adjustSearchResultsByDate(Dictionary<int, ArrayList> searchResults, string dateFilter)
        {
            if(dateFilter == "")
            {
                return searchResults;
            }

            int maxTimeDiff;
            switch(dateFilter)
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
                    maxTimeDiff = int.MaxValue;
                    break;
            }

            List<int> removed = new List<int>();
            foreach (ArrayList data in searchResults.Values) {
                string date = (string)data[4];
                string[] dateSplite = date.Split(new Char[] { '-' });

                DateTime creation = new DateTime(int.Parse("20" + dateSplite[0]), int.Parse(dateSplite[1]), int.Parse(dateSplite[2]));
                TimeSpan diff = DateTime.Today - creation;
                int months = (int)((double)diff.Days / 30.436875); //30.436875 = durchschnittliche Monatslänge (in Tagen)

                if (months > maxTimeDiff)
                {
                    removed.Add((int)data[0]);
                }
            }

            for (int i = 0; i < removed.Count; i++)
            {
                searchResults.Remove(removed[i]);
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
