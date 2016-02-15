using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    /// <summary>
    /// Missing following features:<para/>
    /// # Input for item releating stuff, like Number of Cores or RAM amount.<para/>
    /// # Tags<para/>
    /// </summary>
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

        public void resetEditor()
        {
            resetGUIObject("category", comboBox_category);
            resetGUIObject("subcategory", comboBox_subcategory);
            resetGUIObject("manufacturer", comboBox_manufacturer);
            resetGUIObject("user", comboBox_user);
            resetGUIObject("status", comboBox_status);

            date_creationDate.Value = DateTime.Today;
            label_id.Text = "ID:";
            label_edit.Text = "Last Edit:";
            textBox_name.Text = "";
            textBox_title.Text = "";
            textBox_url.Text = "";
        }

        //Updates all fields regarding the database entry
        public void openExistingItem(int id)
        {
            string sql = "SELECT main.id,category_name, status_name,"
                        + "subcategory_name,user_name, title, url, name, date, edit, manufacturer_name FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN manufacturer ON main.manufacturer = manufacturer.id "
                        + "INNER JOIN user ON main.user = user.id "
                        + "INNER JOIN status ON main.status = status.id "
                        + "WHERE main.id = " + id + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox_category.SelectedIndex = comboBox_category.FindStringExact((string)reader["category_name"]);
                comboBox_subcategory.SelectedIndex = comboBox_subcategory.FindStringExact((string)reader["subcategory_name"]);
                comboBox_manufacturer.SelectedIndex = comboBox_manufacturer.FindStringExact((string)reader["manufacturer_name"]);
                comboBox_user.SelectedIndex = comboBox_user.FindStringExact((string)reader["user_name"]);
                comboBox_status.SelectedIndex = comboBox_status.FindStringExact((string)reader["status_name"]);

                string date = (string)reader["date"];
                string[] dateSplite = date.Split(new Char[] { '-' });

                date_creationDate.Value = new DateTime(int.Parse("20" + dateSplite[0]), int.Parse(dateSplite[1]), int.Parse(dateSplite[2]));

                this.currrentItemId = (int)reader["id"];
                label_id.Text = "ID: " + reader["id"];
                label_edit.Text = "Last Edit: " + reader["edit"];

                textBox_name.Text = reader["name"] + "";
                textBox_title.Text = reader["title"] + "";
                textBox_url.Text = reader["url"] + "";
            }
            reader.Close();
        }

        private void resetGUIObject(String table, ComboBox reference)
        {
            string sql = "SELECT " + table + "_name FROM " + table + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            reference.Items.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reference.Items.Add((string)reader[table + "_name"]);
            }
            reader.Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.searchWindow.Show();
            ClientMain.searchWindow.executeSearch(); //resets the search results
            currrentItemId = -1;
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            resetEditor();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (currrentItemId != -1)
            {
                saveCurrentItem();
            }
            else
            {
                saveNewItem();
            }
        }

        private void button_editTags_Click(object sender, EventArgs e)
        {
            ClientMain.tagWindow.Show();
        }

        private void saveCurrentItem()
        {
            int category = -1, subcategory = -1, manufacturer = -1, user = -1, status = -1;

            category = getItemID("category", comboBox_category);
            subcategory = getItemID("subcategory", comboBox_subcategory);
            manufacturer = getItemID("manufacturer", comboBox_manufacturer);
            user = getItemID("user", comboBox_user);
            status = getItemID("status", comboBox_status);

            if (category != -1 && subcategory != -1 && manufacturer != -1 && user != -1 && status != -1)
            {
                string sql = "UPDATE main " +
                "SET category = " + category + "," +
                "subcategory = " + subcategory + "," +
                "manufacturer = " + manufacturer + "," +
                "status = " + status + "," +
                "title = '" + textBox_title.Text + "'," +
                "name = '" + textBox_name.Text + "'," +
                "url = '" + textBox_url.Text + "'," +
                "date = '" + date_creationDate.Value.ToString("yy-MM-dd") + "'," +
                "edit = '" + DateTime.Now.ToString("yy-MM-dd-HH-mm-ss") + "'," +
                "user = " + user +
                " WHERE id = " + currrentItemId + ";";

                SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Item has been saved.", "Info");
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error Message");
            }
        }

        private void saveNewItem()
        {
            int amount = 0, category = -1, subcategory = -1, manufacturer = -1, user = -1, status = -1;

            string sql = "SELECT id from main;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount++;
            }
            reader.Close();

            category = getItemID("category", comboBox_category);
            subcategory = getItemID("subcategory", comboBox_subcategory);
            manufacturer = getItemID("manufacturer", comboBox_manufacturer);
            user = getItemID("user", comboBox_user);
            status = getItemID("status", comboBox_status);

            if (category != -1 && subcategory != -1 && manufacturer != -1 && user != -1 && status != -1)
            {
                sql = "INSERT INTO main (id,category,subcategory,manufacturer,user,status,title,url,name,date,edit,views) "
                + "VALUES (" +
                amount + "," +
                category + "," +
                subcategory + "," +
                manufacturer + "," +
                user + "," +
                status + "," +
                "'" + textBox_title.Text + "' ," +
                "'" + textBox_url.Text + "' ," +
                "'" + textBox_name.Text + "' ," +
                "'" + date_creationDate.Value.ToString("yy-MM-dd") + "' ," +
                "'" + DateTime.Now.ToString("yy-MM-dd-HH-mm-ss") + "'," +
                0 + ");";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Item has been created.", "Info");
                openExistingItem(amount);
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error Message");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (currrentItemId != -1)
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

        private int getItemID(String table, ComboBox reference)
        {
            int id = -1;
            string sql = "SELECT id FROM " + table + " WHERE " + table + "_name = '" + reference.Text + "';";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["id"];
            }
            reader.Close();

            return id;
        }
    }
}
