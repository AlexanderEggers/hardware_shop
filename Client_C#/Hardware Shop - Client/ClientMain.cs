using System;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    static class ClientMain
    {
        public static DatabaseController databaseController;
        public static SearchWindow searchWindow;
        public static EditorWindow editorWindow;
        public static TagWindow tagWindow;
        public static string user;

        [STAThread]
        static void Main()
        {
            databaseController = new DatabaseController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            searchWindow = new SearchWindow();
            editorWindow = new EditorWindow();
            tagWindow = new TagWindow();

            Application.Run(new LoginWindow());
        }

        public static void exit()
        {
            ClientMain.databaseController.getConnection().Close();
            Application.Exit();
        }
    }
}
