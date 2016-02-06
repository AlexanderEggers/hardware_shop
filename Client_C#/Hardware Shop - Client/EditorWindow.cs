using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class EditorWindow : Form
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.exit();
        }

        //Updates all possible choices according to latest database entries
        public void resetEditor()
        {
            string sql = "SELECT category_name FROM category;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_category.Items.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_category.Items.Add((string)reader["category_name"]);
            }
            reader.Close();


            sql = "SELECT subcategory_name FROM subcategory;";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_subCategory.Items.Clear();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_subCategory.Items.Add((string)reader["subcategory_name"]);
            }
            reader.Close();


            sql = "SELECT username FROM user;";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            comboBox_editor.Items.Clear();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_editor.Items.Add((string)reader["username"]);
            }
            reader.Close();

            //es fehlen noch manufacture und status

            label_id.Text = "ID:";
        }

        //Updates all fields regarding the database entry
        public void openExistingItem(int id)
        {
            string sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE main.id = " + id + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_category.SelectedIndex = comboBox_category.FindStringExact((string)reader["category_name"]);
                comboBox_subCategory.SelectedIndex = comboBox_subCategory.FindStringExact((string)reader["subcategory_name"]);
                comboBox_editor.SelectedIndex = comboBox_editor.FindStringExact((string)reader["username"]);
                label_id.Text = "ID: " + reader["id"];
            }
            reader.Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.searchWindow.Show();
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            resetEditor();
        }
    }
}
