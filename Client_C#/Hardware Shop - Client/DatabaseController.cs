using System;
using System.Data.SQLite;

namespace Hardware_Shop_Client
{
    class DatabaseController
    {
        private SQLiteConnection m_dbConnection;

        public DatabaseController()
        {
            //das sollten wir später anpassen, sodass dies auf die richtige File zugreift, wenn wir die fertige Version haben
            //in Testmodus sollte das erstmal so genügen
            m_dbConnection = new SQLiteConnection("Data Source=../../../../DB.sql;Version=3;");
            m_dbConnection.Open();
        }

        public SQLiteConnection getConnection()
        {
            return m_dbConnection;
        }
    }
}
