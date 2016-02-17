using System.Data.SQLite;

namespace Hardware_Shop_Client
{
    class DatabaseController
    {
        private SQLiteConnection m_dbConnection;

        public DatabaseController()
        {
            m_dbConnection = new SQLiteConnection("Data Source=../../../../DB.sql;Version=3;");
            m_dbConnection.Open();
        }

        public SQLiteConnection getConnection()
        {
            return m_dbConnection;
        }
    }
}
