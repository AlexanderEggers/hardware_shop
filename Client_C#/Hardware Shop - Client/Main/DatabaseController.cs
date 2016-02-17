using System.Data.SQLite;
using System.IO;

namespace Hardware_Shop_Client
{
    class DatabaseController
    {
        private SQLiteConnection m_dbConnection;

        public DatabaseController()
        {
            string path = "../../../../DB.sql";

            if (!File.Exists(path))
            {
                path = "DB.sql";
            }

            m_dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
            m_dbConnection.Open();
        }

        public SQLiteConnection getConnection()
        {
            return m_dbConnection;
        }
    }
}
