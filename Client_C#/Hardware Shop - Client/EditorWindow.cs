using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ClientMain.databaseController.getConnection().Close();
            Application.Exit();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Hide();
            ClientMain.searchWindow.Show();
        }
    }
}
