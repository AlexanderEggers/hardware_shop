using System;
using System.Windows.Forms;

namespace Hardware_Shop_Client.Main
{
    public partial class URLWindow : Form
    {
        public URLWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClientMain.editorWindow.Enabled = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            textBox_urlName.Text = ClientMain.editorWindow.textBox_url.Text;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string[] url = textBox_urlName.Text.Split(new Char[] { ' ' });
            string newURL = "";

            foreach(string part in url)
            {
                if(newURL == "")
                    newURL = part;
                else
                    newURL = newURL + "_" + part;
            }

            ClientMain.editorWindow.textBox_url.Text = newURL;
            Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_urlName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_save_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
