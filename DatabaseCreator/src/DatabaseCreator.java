
import java.sql.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DatabaseCreator {

    private static Connection c;
    private static Statement stmt;

    public DatabaseCreator() throws ClassNotFoundException, SQLException {
        Class.forName("org.sqlite.JDBC");
        c = DriverManager.getConnection("jdbc:sqlite:DB.sql");
        c.setAutoCommit(false);
        System.out.println("Opened database successfully");
    }

    private void builtData() throws Exception {
        stmt = c.createStatement();
        String sql = "CREATE TABLE USERDB "
                + "(USERID          INT     PRIMARY KEY     NOT NULL,"
                + " USERNAME        CHAR(15)                NOT NULL, "
                + " PASSWORD        CHAR(15)                NOT NULL, "
                + " ROLE            BLOB                    NOT NULL)";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "CREATE TABLE CONTENTDB "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " CATEGORY       TEXT                     NOT NULL, "
                + " MANUFACTURER   TEXT                     NOT NULL, "
                + " NAME           TEXT                     NOT NULL, "
                + " MODELL         TEXT                     NOT NULL, "
                + " PRICE          REAL                     NOT NULL, "
                + " TEXT           TEXT                     NOT NULL, "
                + " IMAGE          TEXT                     NOT NULL, "
                + " RELEASE_DATE   TEXT                     NOT NULL, "
                + " LAST_EDIT      INT                      NOT NULL, "
                + " LAST_EDITOR    TEXT                     NOT NULL, "
                + " VIEWS          INT                      NOT NULL)";
        stmt.executeUpdate(sql);
    }

    public static void main(String args[]) {
        try {
            DatabaseCreator creator = new DatabaseCreator();
            creator.builtData();
            stmt.close();
            c.commit();
            c.close();
        } catch (Exception e) {
            Logger.getLogger(DatabaseCreator.class.getName()).log(Level.SEVERE, e.getMessage());
        }
    }
}
