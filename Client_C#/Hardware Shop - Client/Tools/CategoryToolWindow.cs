using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client.Tools
{
    public partial class CategoryToolWindow : Form
    {
        public CategoryToolWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.searchWindow.Enabled = true;
        }

        private void button_createCategory_Click(object sender, EventArgs e)
        {
            int amount = 0;

            string sql = "SELECT id FROM category;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            sql = "INSERT INTO category (id,category_name) "
                + "VALUES (" + amount + ", '" + textBox_createCategory.Text + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Category has been created.", "Info");

            textBox_search.Text = textBox_createCategory.Text;
            executeSearch();
        }

        private void button_editCategory_Click(object sender, EventArgs e)
        {
            int tagID = (int)dataGridView_categories.SelectedRows[0].Cells[0].Value;

            string sql = "UPDATE category " +
                "SET category_name = '" + textBox_editCategory.Text + "'" +
                " WHERE id = " + tagID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Category has been edited.", "Info");

            textBox_search.Text = textBox_editCategory.Text;
            executeSearch();
        }

        private void button_deleteCategory_Click(object sender, EventArgs e)
        {
            int categoryID = (int)dataGridView_categories.SelectedRows[0].Cells[0].Value, amount = 0;

            string sql = "SELECT id FROM main WHERE category = " + categoryID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            if (amount == 0)
            {
                sql = "DELETE FROM category WHERE id = " + categoryID + ";";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Category has been deleted.", "Info");

                textBox_search.Text = "";
                executeSearch();
            }
            else
                MessageBox.Show("Category cannot be deleted because of remaining items related to this category.", "Info");
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

        private void dataGridView_categories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_categories.SelectedRows.Count > 0)
                textBox_editCategory.Text = (string)dataGridView_categories.SelectedRows[0].Cells[1].Value;
        }

        private void executeSearch()
        {
            string sql;

            if (textBox_search.Text != "")
                sql = "SELECT id,category_name FROM category;";
            else
                sql = "SELECT id,category_name FROM category"
                      + " WHERE category_name = '" + textBox_search.Text + "' "
                      + "OR category_name LIKE '%" + textBox_search.Text + "%';";

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            dataGridView_categories.Rows.Clear();
            while (reader.Read())
            {
                int amount = 0;

                string sql2 = "SELECT id FROM main WHERE category = " + reader["id"] + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                    amount++;
                reader2.Close();

                if((string)reader["category_name"] != "")
                {
                    dataGridView_categories.Rows.Add((int)reader["id"], (string)reader["category_name"], amount);
                }
            }

            reader.Close();
        }
    }
}
