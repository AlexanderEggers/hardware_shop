using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client.Tools
{
    public partial class ManufacturerToolWindow : Form
    {
        public ManufacturerToolWindow()
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

            string sql = "SELECT id FROM manufacturer;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                lastID = (int)reader["id"];
            reader.Close();

            sql = "INSERT INTO manufacturer (id,manufacturer_name) "
                + "VALUES (" + (lastID + 1) + ", '" + textBox_create.Text + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Manufacturer has been created.", "Info");

            textBox_search.Text = textBox_create.Text;
            textBox_create.Text = "";
            executeSearch();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            int manufacturerID = (int)dataGridView_results.SelectedRows[0].Cells[0].Value;

            string sql = "UPDATE manufacturer " +
                "SET manufacturer_name = '" + textBox_edit.Text + "'" +
                " WHERE id = " + manufacturerID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Manufacturer has been edited.", "Info");

            textBox_search.Text = textBox_edit.Text;
            executeSearch();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int manufacturerID = (int)dataGridView_results.SelectedRows[0].Cells[0].Value, amount = 0;

            string sql = "SELECT id FROM article WHERE manufacturer = " + manufacturerID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            if (amount == 0)
            {
                sql = "DELETE FROM manufacturer WHERE id = " + manufacturerID + ";";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Manufacturer has been deleted.", "Info");

                textBox_search.Text = "";
                executeSearch();
            }
            else
                MessageBox.Show("Manufacturer cannot be deleted because of rearticleing items related to this manufacturer.", "Info");
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
                sql = "SELECT id,manufacturer_name FROM manufacturer;";
            else
                sql = "SELECT id,manufacturer_name FROM manufacturer"
                      + " WHERE manufacturer_name = '" + textBox_search.Text + "' "
                      + "OR manufacturer_name LIKE '%" + textBox_search.Text + "%';";

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            dataGridView_results.Rows.Clear();
            while (reader.Read())
            {
                int amount = 0;

                string sql2 = "SELECT id FROM article WHERE manufacturer = " + reader["id"] + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                    amount++;
                reader2.Close();

                if ((string)reader["manufacturer_name"] != "")
                {
                    dataGridView_results.Rows.Add((int)reader["id"], (string)reader["manufacturer_name"], amount);
                }
            }

            reader.Close();
        }
    }
}
