using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class EditorWindow : Form
    {
        private int currrentItemId = -1;

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

            date_creationDate.Value = DateTime.Today;
            label_id.Text = "ID:";
            textBox_name.Text = "";
            textBox_title.Text = "";
            textBox_url.Text = "";
        }

        //Updates all fields regarding the database entry
        public void openExistingItem(int id)
        {
            string sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username, title, url, name, date FROM main "
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

                string date = (string)reader["date"];
                string[] dateSplite = date.Split(new Char[] { '-' });

                date_creationDate.Value = new DateTime(int.Parse("20" + dateSplite[0]), int.Parse(dateSplite[1]), int.Parse(dateSplite[2]));

                this.currrentItemId = (int)reader["id"];
                label_id.Text = "ID: " + reader["id"];

                textBox_name.Text = reader["name"] + "";
                textBox_title.Text = reader["title"] + "";
                textBox_url.Text = reader["url"] + "";
            }
            reader.Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.searchWindow.Show();
            ClientMain.searchWindow.executeTest(); //resets the search results
            currrentItemId = -1;
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            resetEditor();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(currrentItemId != -1)
            {
                saveCurrentItem();
            } else
            {
                saveNewItem();
            }
        }

        private void saveCurrentItem()
        {
            int category = -1, subcategory = -1, editor = -1;

            string sql = "SELECT id FROM category WHERE category_name = '" + comboBox_category.Text + "';";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                category = (int)reader["id"];
            }
            reader.Close();

            sql = "SELECT id FROM subcategory WHERE subcategory_name = '" + comboBox_subCategory.Text + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                subcategory = (int)reader["id"];
            }
            reader.Close();

            sql = "SELECT id FROM user WHERE username = '" + comboBox_editor.Text + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                editor = (int)reader["id"];
            }
            reader.Close();

            if (category != -1 && subcategory != -1 && editor != -1)
            {
                sql = "UPDATE main " +
                "SET category = " + category + "," +
                "subcategory = " + subcategory + "," +
                "title = '" + textBox_title.Text + "'," +
                "name = '" + textBox_name.Text + "'," +
                "url = '" + textBox_url.Text + "'," +
                "date = '" + date_creationDate.Value.ToString("yy-MM-dd") + "'," +
                "editor = " + editor +
                " WHERE id = " + currrentItemId + ";";

                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Item has been saved.", "Info");
            } else
            {
                MessageBox.Show("Something went wrong.", "Error Message");
            }
        }

        private void saveNewItem()
        {
            int amount = 0, category = -1, subcategory = -1, editor = -1;

            string sql = "SELECT id from main;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount++;
            }
            reader.Close();

            sql = "SELECT id FROM category WHERE category_name = '" + comboBox_category.Text + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                category = (int)reader["id"];
            }
            reader.Close();

            sql = "SELECT id FROM subcategory WHERE subcategory_name = '" + comboBox_subCategory.Text + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                subcategory = (int)reader["id"];
            }
            reader.Close();

            sql = "SELECT id FROM user WHERE username = '" + comboBox_editor.Text + "';";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                editor = (int)reader["id"];
            }
            reader.Close();

            if (category != -1 && subcategory != -1 && editor != -1)
            {
                sql = "INSERT INTO main (id,category,subcategory,manufacturer,editor,status,title,url,name,date,last_edit,views) "
                + "VALUES (" +
                amount + "," +
                category + "," +
                subcategory + "," +
                10 + "," +
                editor + "," +
                0 + "," +
                "'" + textBox_title.Text + "' ," +
                "'" + textBox_url.Text + "' ," +
                "'" + textBox_name.Text + "' ," +
                "'" + date_creationDate.Value.ToString("yy-MM-dd") + "' ," +
                "'15-11-04-00-11'," +
                0 + ");";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Item has been created.", "Info");
                openExistingItem(amount);
            } else
            {
                MessageBox.Show("Something went wrong.", "Error Message");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if(currrentItemId != -1)
            {
                deleteItem(currrentItemId);
            }
        }

        private void deleteItem(int id)
        {
            string sql = "DELETE FROM main WHERE id = " + id + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Item has been deleted.", "Info");
            resetEditor();
        }
    }
}
