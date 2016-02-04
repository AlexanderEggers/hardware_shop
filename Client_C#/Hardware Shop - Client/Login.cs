using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.databaseController.getConnection().Close();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginUser();
            }
        }

        private void loginUser()
        {
            string sql = "SELECT role, password FROM user WHERE username = '"
                         + textBox_user.Text + "';";
            SQLiteCommand command = new SQLiteCommand(sql, Program.databaseController.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                if((string)reader["password"] == textBox_password.Text && 
                    (int)reader["role"] == 1)
                {
                    Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
            } else
            {
                MessageBox.Show("Invalid input. Try again.", "Error Message");
                Console.WriteLine("User fehlt!!");
            }
            reader.Close();
        }
    }
}
