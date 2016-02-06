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

        private void button_search_Click(object sender, EventArgs e)
        {
            executeTest();
        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                executeTest();

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

        private void executeTest()
        {
            string text = this.textBox_search.Text;
            String inputCategory;

            if (text == "")
            {
                return;
            }

            inputCategory = "main.id"; //aktuell nur zum testen

            string sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE " + inputCategory + " = " + text + ";";
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
    }
}
