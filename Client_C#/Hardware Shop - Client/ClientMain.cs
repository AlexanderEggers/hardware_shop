using System;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    static class ClientMain
    {
        public static DatabaseController databaseController;
        public static SearchWindow searchWindow;
        public static EditorWindow editorWindow;

        [STAThread]
        static void Main()
        {
            databaseController = new DatabaseController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            searchWindow = new SearchWindow();
            editorWindow = new EditorWindow();

            Application.Run(new LoginWindow());
        }

        public static void exit()
        {
            ClientMain.databaseController.getConnection().Close();
            Application.Exit();
        }
    }
}
