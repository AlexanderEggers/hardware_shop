using System;
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
        /// # Search by category, subcategory, manufacturer, editor, status<para/>
        /// # Function for sort by and sort desc<para/>
        /// # Function to list all items from the last 1,3,6,12 month (example)<para/>
        /// # Function to list all item which have been last edited the last 1,3,6,12 month (example)
        /// </summary>
        public void executeSearch()
        {
            string text = this.textBox_search.Text;
            String sql;
            int tempItemID;

            if (text == "")
            {
                resetSearchWindow();
                return;
            }

            if (int.TryParse(textBox_search.Text, out tempItemID))
            {
                sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE main.id = " + text + " LIMIT " + getMaxResultsInput() + " ;";
            } else
            {
                sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE main.title LIKE '%" + text + "%' LIMIT " + getMaxResultsInput() + " ;";
            }
            
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            /**
             * SELECT name FROM MAIN LEFT JOIN category USING(ID)
             */

            searchDataView.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                searchDataView.Rows.Add((int)reader["id"], (string)reader["username"],
                    (string)reader["category_name"], (string)reader["subcategory_name"]);
            }
            reader.Close();
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
