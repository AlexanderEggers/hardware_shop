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
        public static int user_role;

        public readonly static int USER_ROLE_ADMIN = 3;
        public readonly static int USER_ROLE_MANAGER = 2;
        public readonly static int USER_ROLE_EDITOR = 1;
        public readonly static int USER_ROLE_USER = 0;

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
