using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
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
            resetGUIObject("category", comboBox_category);
            resetGUIObject("subcategory", comboBox_subcategory);
            resetGUIObject("manufacturer", comboBox_manufacturer);
            resetGUIObject("user", comboBox_user);
            resetGUIObject("status", comboBox_status);

            comboBox_date.SelectedText = "";
            comboBox_edit.SelectedText = "";

            comboBox_sortBy.SelectedText = "";
            checkBox_sortDescending.CheckState = CheckState.Unchecked;

            comboBox_maxResults.Text = "30";
            textBox_search.Text = "";

            string sql = "SELECT main.id,category_name,"
                        + "manufacturer_name,user_name FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN manufacturer ON main.manufacturer = manufacturer.id "
                        + "INNER JOIN user ON main.user = user.id LIMIT " + comboBox_maxResults.Text + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["user_name"],
                    (string)reader["category_name"], (string)reader["manufacturer_name"]);
            }
            reader.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            int itemID = -1;

            if (int.TryParse(textBox_search.Text, out itemID) && isAccessible(itemID))
            {
                addContentAccessBlock(itemID);
                Hide();
                ClientMain.editorWindow.resetEditor();
                ClientMain.editorWindow.openExistingItem(itemID);
                ClientMain.editorWindow.Show();
            }
            else
                executeSearch();
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
            int itemID = (int)searchDataView.Rows[e.RowIndex].Cells[0].Value;

            if (isAccessible(itemID))
            {
                addContentAccessBlock(itemID);
                Hide();
                ClientMain.editorWindow.resetEditor();
                ClientMain.editorWindow.openExistingItem(itemID);
                ClientMain.editorWindow.Show();
            }
        }

        private void button_editor_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.editorWindow.resetEditor();
            ClientMain.editorWindow.Show();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            resetSearchWindow();
        }

        public void executeSearch()
        {
            string text = textBox_search.Text;
            int tempItemID;
            bool insertFilter = false, numberic = false;

            string sql = "SELECT main.id,category_name,"
                        + "manufacturer_name,user_name,date,edit FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN manufacturer ON main.manufacturer = manufacturer.id "
                        + "INNER JOIN user ON main.user = user.id "
                        + "WHERE";

            if (int.TryParse(textBox_search.Text, out tempItemID))
            {
                sql = sql + " main.id = " + text;
                insertFilter = true;
                numberic = true;
            }
            else if (textBox_search.Text != "")
            {
                sql = sql + " main.title LIKE '%" + text + "%'";
                insertFilter = true;
            }

            if (!numberic)
            {
                sql = sql + getFilterSQLData("category", comboBox_category, insertFilter, out insertFilter)
                      + getFilterSQLData("subcategory", comboBox_subcategory, insertFilter, out insertFilter)
                      + getFilterSQLData("user", comboBox_user, insertFilter, out insertFilter)
                      + getFilterSQLData("manufacturer", comboBox_manufacturer, insertFilter, out insertFilter)
                      + getFilterSQLData("status", comboBox_status, insertFilter, out insertFilter);

                if (comboBox_sortBy.Text != "")
                {
                    if (checkBox_sortDescending.Checked)
                        sql = sql + " ORDER BY main." + comboBox_sortBy.Text + " ASC";
                    else
                        sql = sql + " ORDER BY main." + comboBox_sortBy.Text + " DESC";
                }
            }
            else
            {
                string backupText = textBox_search.Text;
                resetSearchWindow();
                textBox_search.Text = backupText;
                textBox_search.Select(backupText.Length, 0);
            }

            sql = sql + " LIMIT " + comboBox_maxResults.Text + " ;";

            if (sql.Contains("WHERE ORDER BY") || sql.Contains("WHERE LIMIT"))
                sql = sql.Replace(" WHERE", "");

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
                data.Add(reader["edit"]);

                searchResults.Add((int)data[0], data);
            }
            reader.Close();

            searchResults = adjustSearchResultsByDate(searchResults, comboBox_date.Text, "date");
            searchResults = adjustSearchResultsByDate(searchResults, comboBox_edit.Text, "edit");
            searchDataView.Rows.Clear();

            List<int> keyList = new List<int>(searchResults.Keys);
            for (int i = 0; i <= int.Parse(comboBox_maxResults.Text) && i < keyList.Count; i++)
            {
                ArrayList data = searchResults[keyList[i]];
                searchDataView.Rows.Add(data[0], data[1], data[2], data[3]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchResults">Dictionary which hold a arraylist structure: id, user_name, 
        /// category_name, manufacture_name, date, edit</param>
        /// <param name="dateFilter">Reference which date filter have been selected</param>
        /// <returns></returns>
        private Dictionary<int, ArrayList> adjustSearchResultsByDate(Dictionary<int, ArrayList> searchResults, string dateFilter, string reference)
        {
            if (dateFilter == "")
                return searchResults;

            int maxTimeDiff;
            switch (dateFilter)
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
            foreach (ArrayList data in searchResults.Values)
            {
                string date;

                if (reference == "Date")
                    date = (string)data[4];
                else
                    date = (string)data[5];

                string[] dateSplite = date.Split(new Char[] { '-' });

                DateTime creation = new DateTime(int.Parse("20" + dateSplite[0]), int.Parse(dateSplite[1]), int.Parse(dateSplite[2]));
                TimeSpan diff = DateTime.Today - creation;
                int months = (int)((double)diff.Days / 30.436875); //30.436875 = durchschnittliche Monatslänge (in Tagen)

                if (months > maxTimeDiff)
                    removed.Add((int)data[0]);
            }

            for (int i = 0; i < removed.Count; i++)
                searchResults.Remove(removed[i]);

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
                        return " AND main." + type + " = " + id;
                    else
                        return " main." + type + " = " + id;
                }
                else
                    return "";
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
                id = (int)reader["id"];
            reader.Close();

            return id != -1 ? true : false;
        }

        private void resetGUIObject(String table, ComboBox reference)
        {
            string sql = "SELECT " + table + "_name FROM " + table + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reference.Items.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                reference.Items.Add((string)reader[table + "_name"]);
            reader.Close();
        }

        /// <summary>
        /// Checks if a certain item can be access regarding the rule that only ONE editor can access a specific item.
        /// </summary>
        /// <param name="itemID">Specific item id which needs to be checked.</param>
        /// <returns>boolean which let the open request through or not.</returns>
        private bool isAccessible(int itemID)
        {
            string user = "", date = "";

            string sql = "SELECT user_name, date FROM content_access "
                        + "INNER JOIN user ON content_access.user_id = user.id "
                        + "WHERE main_id = " + itemID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = (string)reader["user_name"];
                date = (string)reader["date"];
            }
            reader.Close();

            if (user == "" && date == "")
            {
                return true;
            }
            else
            {
                if (user == ClientMain.user)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("This item is currently opened by " + user + " since " + date + ".", "Info");
                    return false;
                }
            }
        }

        private void addContentAccessBlock(int itemID)
        {
            int amount = 0, userID = -1;

            string sql = "SELECT id FROM content_access;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount++;
            }
            reader.Close();

            sql = "SELECT id FROM user WHERE user_name = '" + ClientMain.user + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount++;
            }
            reader.Close();

            if (userID != -1)
            {
                sql = "INSERT INTO content_access (id,main_id,user_id,date) "
                + "VALUES (" + amount + ", " + itemID + ", " + userID + ", " + DateTime.Now + ");";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();
            }
        }
    }
}
