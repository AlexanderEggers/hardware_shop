﻿using System;
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
            string sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id LIMIT " + getMaxResultsInput() + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["username"],
                    (string)reader["category_name"], (string)reader["subcategory_name"]);
            }
            reader.Close();


            sql = "SELECT category_name FROM category;";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_category.Items.Clear();
            comboBox_category.Items.Add("");

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_category.Items.Add((string)reader["category_name"]);
            }
            reader.Close();


            sql = "SELECT subcategory_name FROM subcategory;";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_subCategory.Items.Clear();
            comboBox_subCategory.Items.Add("");

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_subCategory.Items.Add((string)reader["subcategory_name"]);
            }
            reader.Close();


            sql = "SELECT username FROM user;";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_editor.Items.Clear();
            comboBox_editor.Items.Add("");

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_editor.Items.Add((string)reader["username"]);
            }
            reader.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            int itemID = -1;

            if(int.TryParse(textBox_search.Text, out itemID))
            {
                Hide();
                ClientMain.editorWindow.resetEditor();
                ClientMain.editorWindow.openExistingItem(itemID);
                ClientMain.editorWindow.Show();
            } else
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

        /// <summary>
        /// Search is only possible via item id or item title.<para/>
        /// <para/>
        /// Current missing features:<para/>
        /// # Search by manufacturer, status<para/>
        /// # Function for sort by and sort desc<para/>
        /// # Function to list all items from the last 1,3,6,12 month (example)<para/>
        /// # Function to list all item which have been last edited the last 1,3,6,12 month (example)
        /// </summary>
        public void executeSearch()
        {
            string text = this.textBox_search.Text;
            String sql;
            int tempItemID;
            bool insertFilter = false;

            sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE";

            if (int.TryParse(textBox_search.Text, out tempItemID))
            {
                sql = sql +  "main.id = " + text;
                insertFilter = true;
            } else if(textBox_search.Text != "")
            {
                sql = sql +  "main.title LIKE '%" + text + "%'";
                insertFilter = true;
            }

            sql = sql + getFilterSQLData("category", comboBox_category, insertFilter, out insertFilter) 
                      + getFilterSQLData("subcategory", comboBox_subCategory, insertFilter, out insertFilter)
                      + getFilterSQLData("editor", comboBox_editor, insertFilter, out insertFilter) 
                      + getFilterSQLData("manufacture", comboBox_manufacture, insertFilter, out insertFilter)
                      + getFilterSQLData("status", comboBox_status, insertFilter, out insertFilter) 
                      + " LIMIT " + getMaxResultsInput() + " ;";

            if(sql.Contains("WHERE LIMIT"))
            {
                resetSearchWindow();
                return;
            }

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            /**
             * SELECT name FROM MAIN LEFT JOIN category USING(ID)
             */

            Console.WriteLine(sql);

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["username"],
                    (string)reader["category_name"], (string)reader["subcategory_name"]);
            }
            reader.Close();
        }

        private string getFilterSQLData(string type, ComboBox reference, bool filterBefore, out bool success)
        {
            if (reference.Text != "")
            {
                int sqlID = getSQLContentID(reference.Text, type);

                if (sqlID != -1)
                {
                    success = true;

                    if (filterBefore)
                    {
                        return " AND main." + type + " = " + sqlID;
                    } else
                    {
                        return " main." + type + " = " + sqlID;
                    }
                } else
                {
                    success = false;
                    return "";
                }
            } else
            {
                success = false;
                return "";
            }
        }

        private int getSQLContentID(string reference, string type)
        {
            int sqlID = -1;
            string sql = "SELECT id FROM " + type
                        + " WHERE " + type + "_name = '" + reference + "' ;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sqlID = (int)reader["id"];
            }
            reader.Close();

            return sqlID;
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
                return int.MaxValue;
            }
        }
    }
}
