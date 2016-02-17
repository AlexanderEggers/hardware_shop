using System;
using System.Collections;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class TagWindow : Form
    {
        private ArrayList selectedTags, normalTags, masterTags, removedTags;
        private int itemID;

        public TagWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.editorWindow.Enabled = true;
            ClientMain.editorWindow.resetTagInfos();
        }

        public void openWindow(int itemID)
        {
            this.itemID = itemID;
            selectedTags = new ArrayList();
            normalTags = new ArrayList();
            masterTags = new ArrayList();
            removedTags = new ArrayList();

            dataGridView_tags.Rows.Clear();
            dataGridView_normalTags.Rows.Clear();
            dataGridView_masterTags.Rows.Clear();

            string sql = "SELECT tag_id, tag_category, tag_name, views FROM search "
                        + "INNER JOIN tag ON search.tag_id = tag.id "
                        + "WHERE article_id = " + itemID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int tagID = (int)reader["tag_id"];

                if ((int)reader["tag_category"] == 0)
                {
                    dataGridView_normalTags.Rows.Add(tagID, reader["tag_name"], reader["Views"]);
                    normalTags.Add(tagID);
                }
                else
                {
                    dataGridView_masterTags.Rows.Add(tagID, reader["tag_name"], reader["Views"]);
                    masterTags.Add(tagID);
                }
            }
            reader.Close();
        }

        private void dataGridView_tags_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            addNewTag((int)dataGridView_tags.Rows[e.RowIndex].Cells[0].Value,
                    (string)dataGridView_tags.Rows[e.RowIndex].Cells[1].Value);
        }

        private void button_addTag_Click(object sender, EventArgs e)
        {
            if (dataGridView_tags.SelectedRows.Count > 0)
                addNewTag((int)dataGridView_tags.SelectedRows[0].Cells[0].Value,
                    (string)dataGridView_tags.SelectedRows[0].Cells[1].Value);
        }

        private void button_addMasterTag_Click(object sender, EventArgs e)
        {
            if (dataGridView_normalTags.SelectedRows.Count > 0)
            {
                int tagID = (int)dataGridView_normalTags.SelectedRows[0].Cells[0].Value;

                if (!masterTags.Contains(tagID))
                {
                    masterTags.Add(tagID);
                    normalTags.Remove(tagID);
                    dataGridView_masterTags.Rows.Add(tagID,
                        dataGridView_normalTags.SelectedRows[0].Cells[1].Value, getTagViews(tagID));
                    dataGridView_normalTags.Rows.Remove(dataGridView_normalTags.SelectedRows[0]);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int lastID = 0;

            string sql = "SELECT id from search;";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                lastID = (int)reader["id"];
            reader.Close();

            foreach (int tagID in selectedTags)
            {
                int tagCategory;

                if (normalTags.Contains(tagID))
                    tagCategory = 0;
                else
                    tagCategory = 1;

                sql = "INSERT INTO search (id,article_id,tag_id,tag_category,views) "
                            + "VALUES ("
                            + (lastID + 1) + ","
                            + itemID + ","
                            + tagID + ","
                            + tagCategory + ","
                            + " 0);";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();

                lastID++;
            }

            foreach (int tagID in removedTags)
            {
                sql = "DELETE FROM search WHERE id = " + tagID + ";";
                command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());
                command.ExecuteNonQuery();
            }

            Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
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

        private void button_removeTag_Click(object sender, EventArgs e)
        {
            if (dataGridView_normalTags.SelectedRows.Count > 0)
            {
                int tagID = (int)dataGridView_normalTags.SelectedRows[0].Cells[0].Value;
                normalTags.Remove(tagID);
                deleteTag(tagID);
                dataGridView_normalTags.Rows.Remove(dataGridView_normalTags.SelectedRows[0]);
            }
        }

        private void button_removeMasterTag_Click(object sender, EventArgs e)
        {
            if (dataGridView_masterTags.SelectedRows.Count > 0)
            {
                int tagID = (int)dataGridView_masterTags.SelectedRows[0].Cells[0].Value;
                masterTags.Remove(tagID);
                deleteTag(tagID);
                dataGridView_masterTags.Rows.Remove(dataGridView_masterTags.SelectedRows[0]);
            }
        }

        private void dataGridView_normalTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button_removeTag_Click(sender, e);
        }

        private void dataGridView_masterTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button_removeMasterTag_Click(sender, e);

        }

        private void deleteTag(int tagID)
        {
            if (selectedTags.Contains(tagID))
                selectedTags.Remove(tagID);
            else
                removedTags.Add(tagID);
        }

        private void addNewTag(int tagID, String name)
        {
            if (!checkSelectedTags(tagID))
            {
                dataGridView_normalTags.Rows.Add(tagID, name, getTagViews(tagID));
                selectedTags.Add(tagID);
                normalTags.Add(tagID);

                if (removedTags.Contains(tagID))
                    removedTags.Remove(tagID);
            }
        }

        private bool checkSelectedTags(int tagID)
        {
            return normalTags.Contains(tagID) || masterTags.Contains(tagID) || selectedTags.Contains(tagID);
        }

        private void executeSearch()
        {
            string searchText = textBox_search.Text;
            string sql = "SELECT id,tag_name FROM tag "
                        + "WHERE tag_name = '" + searchText + "' OR tag_name LIKE '%" + searchText + "%';";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                dataGridView_tags.Rows.Add(reader["id"], reader["tag_name"]);
            reader.Close();
        }

        private int getTagViews(int tagID)
        {
            string sql = "SELECT views FROM search "
                        + "WHERE tag_id = " + tagID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, ClientMain.databaseController.getConnection());

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                return (int)reader["views"];
            reader.Close();

            return 0;
        }
    }
}
