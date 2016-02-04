using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //aktuell noch nicht optimal aber funktioniert erstmal
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.databaseController.getConnection().Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executeTest();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine("Double Click Test");
        }

        private void executeTest()
        {
            string text = this.textBox1.Text;
            String inputCategory;

            if (text == "")
            {
                return;
            }

            inputCategory = "main.id"; //aktuell nur zum testen

            string sql = "SELECT main.id,category_name,"
                        + "subcategory_name,username FROM main "
                        + "INNER JOIN category ON main.category = category.id "
                        + "INNER JOIN subcategory ON main.subcategory = subcategory.id "
                        + "INNER JOIN user ON main.editor = user.id "
                        + "WHERE " + inputCategory + " = " + text + ";";
                SQLiteCommand command = new SQLiteCommand(sql, Program.databaseController.getConnection());
            /**
             * SELECT name FROM MAIN LEFT JOIN category USING(ID)
             */

            /**
             * Adding/Deleting list objects and it's content dynamically to the
             * search window based on the content which has been found
             */
            dataGridView1.Rows.Clear();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"]);

                dataGridView1.Rows.Add((int)reader["id"], (string)reader["username"], 
                    (string)reader["category_name"], (string)reader["subcategory_name"]);
            }
            reader.Close();
        }
    }
}
