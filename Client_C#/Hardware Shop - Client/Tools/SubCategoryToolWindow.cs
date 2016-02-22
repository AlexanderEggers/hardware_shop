using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client.Tools
{
    public partial class SubCategoryToolWindow : Form
    {
        public SubCategoryToolWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.searchWindow.Enabled = true;
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            int lastID = 0;

            string sql = "SELECT id FROM subcategory;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                lastID = (int)reader["id"];
            reader.Close();

            sql = "INSERT INTO subcategory (id,subcategory_name) "
                + "VALUES (" + (lastID + 1) + ", '" + textBox_create.Text + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Subcategory has been created.", "Info");

            textBox_search.Text = textBox_create.Text;
            textBox_create.Text = "";
            executeSearch();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            int subcategoryID = (int)dataGridView_results.SelectedRows[0].Cells[0].Value;

            string sql = "UPDATE subcategory " +
                "SET subcategory_name = '" + textBox_edit.Text + "'" +
                " WHERE id = " + subcategoryID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Subcategory has been edited.", "Info");

            textBox_search.Text = textBox_edit.Text;
            executeSearch();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int subcategoryID = (int)dataGridView_results.SelectedRows[0].Cells[0].Value, amount = 0;

            string sql = "SELECT id FROM article WHERE subcategory = " + subcategoryID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            if (amount == 0)
            {
                sql = "DELETE FROM subcategory WHERE id = " + subcategoryID + ";";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Subcategory has been deleted.", "Info");

                textBox_search.Text = "";
                executeSearch();
            }
            else
                MessageBox.Show("Subcategory cannot be deleted because of remaining items related to this subcategory.", "Info");
        }

        private void button_search_Click(object sender, EventArgs e)
        {
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

        private void dataGridView_results_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_results.SelectedRows.Count > 0)
                textBox_edit.Text = (string)dataGridView_results.SelectedRows[0].Cells[1].Value;
        }

        private void executeSearch()
        {
            string sql;

            if (textBox_search.Text == "")
                sql = "SELECT id,subcategory_name FROM subcategory;";
            else
                sql = "SELECT id,subcategory_name FROM subcategory"
                      + " WHERE subcategory_name = '" + textBox_search.Text + "' "
                      + "OR subcategory_name LIKE '%" + textBox_search.Text + "%';";

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            dataGridView_results.Rows.Clear();
            while (reader.Read())
            {
                int amount = 0;

                string sql2 = "SELECT id FROM article WHERE subcategory = " + reader["id"] + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                    amount++;
                reader2.Close();

                if ((string)reader["subcategory_name"] != "")
                {
                    dataGridView_results.Rows.Add((int)reader["id"], (string)reader["subcategory_name"], amount);
                }
            }

            reader.Close();
        }
    }
}
