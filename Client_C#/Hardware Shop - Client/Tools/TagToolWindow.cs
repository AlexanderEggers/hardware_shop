using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class TagToolWindow : Form
    {
        public TagToolWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.searchWindow.Enabled = true;
        }

        private void button_createTag_Click(object sender, EventArgs e)
        {
            int amount = 0;

            string sql = "SELECT id FROM tag;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount++;
            }
            reader.Close();

            sql = "INSERT INTO tag (id,tag_name) "
                + "VALUES (" + amount + ", '" + textBox_createName.Text + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Tag has been created.", "Info");

            textBox_search.Text = textBox_createName.Text;
            executeSearch();
        }

        private void button_editTag_Click(object sender, EventArgs e)
        {
            int tagID = (int)dataGridView_tags.SelectedRows[0].Cells[0].Value;

            string sql = "UPDATE tag " +
                "SET tag_name = '" + textBox_editTag.Text + "'" +
                " WHERE id = " + tagID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Tag has been edited.", "Info");

            textBox_search.Text = textBox_editTag.Text;
            executeSearch();
        }

        private void button_deleteTag_Click(object sender, EventArgs e)
        {
            int tagID = (int)dataGridView_tags.SelectedRows[0].Cells[0].Value;

            string sql = "DELETE FROM tag WHERE id = " + tagID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Tag has been deleted.", "Info");

            textBox_search.Text = "";
            executeSearch();
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

        private void dataGridView_tags_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView_tags.SelectedRows.Count > 0)
                textBox_editTag.Text = (string)dataGridView_tags.SelectedRows[0].Cells[1].Value;
        }

        private void executeSearch()
        {
            string sql;

            if (textBox_search.Text != "")
                sql = "SELECT id,tag_name FROM tag;";
            else
                sql = "SELECT id,tag_name FROM tag"
                      + " WHERE tag_name = '" + textBox_search.Text + "' "
                      + "OR tag_name LIKE '%" + textBox_search.Text + "%';";

            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            dataGridView_tags.Rows.Clear();
            while (reader.Read())
                dataGridView_tags.Rows.Add((int)reader["id"], (string)reader["tag_name"]);
            reader.Close();
        }
    }
}
