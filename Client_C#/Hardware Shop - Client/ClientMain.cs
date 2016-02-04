using System;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    static class ClientMain
    {
        public static DatabaseController databaseController;

        [STAThread]
        static void Main()
        {
            databaseController = new DatabaseController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow());
        }
    }
}
