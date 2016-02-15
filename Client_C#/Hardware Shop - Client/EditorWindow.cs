using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    /// <summary>
    /// Missing feature:
    /// # Function in editor/search window to use the content access feature to block user.
    /// </summary>
    public partial class EditorWindow : Form
    {
        private int currentItemId = -1;

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
            comboBox_user.Text = ClientMain.user;
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

                currentItemId = (int)reader["id"];
                label_id.Text = "ID: " + reader["id"];
                label_edit.Text = "Last Edit: " + reader["edit"];

                textBox_name.Text = reader["name"] + "";
                textBox_title.Text = reader["title"] + "";
                textBox_url.Text = reader["url"] + "";
            }
            reader.Close();

            resetTagWindows();
            initContentTable();
        }

        public void initContentTable()
        {
            dataGridView_content.Rows.Clear();

            if (comboBox_category.Text != "")
            {
                Dictionary<int, string> content = new Dictionary<int, string>();

                string sql = "SELECT value1, value2 FROM content_input "
                + "WHERE main_id = " + currentItemId + ";";
                SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    content.Add((int)reader["value1"], (string)reader["value2"]);
                reader.Close();

                string sql2 = "SELECT id, value1 FROM input "
                + "WHERE category_id = " + getItemID("category", comboBox_category) + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (content.ContainsKey((int)reader2["id"]))
                        dataGridView_content.Rows.Add(reader2["value1"], content[(int)reader2["id"]]);
                    else
                        dataGridView_content.Rows.Add(reader2["value1"], "");
                }
                reader2.Close();
            }
        }

        private void comboBox_category_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = "DELETE FROM content_input WHERE main_id = " + currentItemId + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();

            initContentTable();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.searchWindow.Show();
            ClientMain.searchWindow.executeSearch(); //resets the search results
            currentItemId = -1;
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            resetEditor();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (currentItemId != -1)
                saveCurrentItem();
            else
                saveNewItem();
        }

        private void button_editTags_Click(object sender, EventArgs e)
        {
            Enabled = false;
            ClientMain.tagWindow = new TagWindow();
            ClientMain.tagWindow.Show();
            ClientMain.tagWindow.openWindow(currentItemId);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (currentItemId != -1)
                deleteItem(currentItemId);
        }

        private void saveNewItem()
        {
            int amount = 0, category = -1, subcategory = -1, manufacturer = -1, user = -1, status = -1;

            string sql = "SELECT id from main;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
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

                saveContentFields();

                MessageBox.Show("Item has been created.", "Info");
                openExistingItem(amount);
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error Message");
            }
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
                " WHERE id = " + currentItemId + ";";

                SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                saveContentFields();

                MessageBox.Show("Item has been saved.", "Info");
            }
            else
                MessageBox.Show("Something went wrong.", "Error Message");
        }

        private void saveContentFields()
        {
            for (int i = 0; i < dataGridView_content.Rows.Count; i++)
            {
                string value1 = (string)dataGridView_content.Rows[i].Cells[0].Value;
                string value2 = (string)dataGridView_content.Rows[i].Cells[1].Value;
                int contentID = -1;

                string sql = "SELECT id FROM input "
                + "WHERE value1 = '" + value1 + "';";
                SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    contentID = (int)reader["id"];
                reader.Close();

                if (contentID != -1)
                {
                    bool success = false;
                    sql = "SELECT value2 FROM content_input "
                    + "WHERE main_id = " + currentItemId + " AND value1 = " + contentID + ";";
                    command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

                    reader = command.ExecuteReader();
                    while (reader.Read())
                        success = true;
                    reader.Close();

                    if (success)
                        updateContent(contentID, value2);
                    else
                        insertNewContent(contentID, value2);
                }
            }
        }

        private void insertNewContent(int value1, string value2)
        {
            int amount = 0;

            string sql = "SELECT id FROM content_input;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                amount++;
            reader.Close();

            sql = "INSERT INTO content_input (id,main_id,value1,value2) "
                + "VALUES (" + amount + "," + currentItemId + "," + value1 + ", '" + value2 + "');";
            command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();
        }

        private void updateContent(int value1, string value2)
        {
            string sql = "UPDATE content_input " +
                "SET value2 = '" + value2 + "'" +
                " WHERE id = " + value1 + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
            command.ExecuteNonQuery();
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
                id = (int)reader["id"];
            reader.Close();

            return id;
        }

        public void resetTagWindows()
        {
            dataGridView_normalTags.Rows.Clear();
            dataGridView_masterTags.Rows.Clear();

            string sql = "SELECT tag_id, tag_category, tag_name, views FROM search "
                        + "INNER JOIN tag ON search.tag_id = tag.id "
                        + "WHERE main_id = " + currentItemId + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int tagID = (int)reader["tag_id"];

                if ((int)reader["tag_category"] == 0)
                {
                    dataGridView_normalTags.Rows.Add(tagID, reader["tag_name"], reader["Views"]);
                }
                else
                {
                    dataGridView_masterTags.Rows.Add(tagID, reader["tag_name"], reader["Views"]);
                }
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
                reference.Items.Add((string)reader[table + "_name"]);
            reader.Close();
        }
    }
}
