using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Shop_Client
{
    static class Program
    {
        public static DatabaseController databaseController;

        [STAThread]
        static void Main()
        {
            databaseController = new DatabaseController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        //TODO: Exit Funktion überschreiben, sodass die Verbindung zur DB geschlossen wird
    }
}
