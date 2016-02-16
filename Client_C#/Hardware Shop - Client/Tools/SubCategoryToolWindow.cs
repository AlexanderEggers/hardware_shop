using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button_createSubCategory_Click(object sender, EventArgs e)
        {
            int amount = 0;

            string sql = "SELECT id FROM subcategory;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            sql = "INSERT INTO subcategory (id,subcategory_name) "
                + "VALUES (" + amount + ", '" + textBox_createSubCategory.Text + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Subcategory has been created.", "Info");

            textBox_search.Text = textBox_createSubCategory.Text;
            executeSearch();
        }

        private void button_editSubCategory_Click(object sender, EventArgs e)
        {
            int subcategoryID = (int)dataGridView_subcategories.SelectedRows[0].Cells[0].Value;

            string sql = "UPDATE subcategory " +
                "SET subcategory_name = '" + textBox_editSubCategory.Text + "'" +
                " WHERE id = " + subcategoryID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Subcategory has been edited.", "Info");

            textBox_search.Text = textBox_editSubCategory.Text;
            executeSearch();
        }

        private void button_deleteSubCategory_Click(object sender, EventArgs e)
        {
            int subcategoryID = (int)dataGridView_subcategories.SelectedRows[0].Cells[0].Value, amount = 0;

            string sql = "SELECT id FROM main WHERE subcategory = " + subcategoryID + ";";
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

        private void dataGridView_subcategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_subcategories.SelectedRows.Count > 0)
                textBox_editSubCategory.Text = (string)dataGridView_subcategories.SelectedRows[0].Cells[1].Value;
        }

        private void executeSearch()
        {
            string sql;

            if (textBox_search.Text != "")
                sql = "SELECT id,subcategory_name FROM subcategory;";
            else
                sql = "SELECT id,subcategory_name FROM subcategory"
                      + " WHERE subcategory_name = '" + textBox_search.Text + "' "
                      + "OR subcategory_name LIKE '%" + textBox_search.Text + "%';";

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            dataGridView_subcategories.Rows.Clear();
            while (reader.Read())
            {
                int amount = 0;

                string sql2 = "SELECT id FROM main WHERE subcategory = " + reader["id"] + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                    amount++;
                reader2.Close();

                if ((string)reader["subcategory_name"] != "")
                {
                    dataGridView_subcategories.Rows.Add((int)reader["id"], (string)reader["subcategory_name"], amount);
                }
            }

            reader.Close();
        }
    }
}
