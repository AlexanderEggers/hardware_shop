
import java.io.File;
import java.io.IOException;
import java.sql.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DatabaseCreator {

    private static Connection c;
    private static Statement stmt;

    public DatabaseCreator() throws ClassNotFoundException, SQLException, IOException {
        String path = "../DB.sql";
        File file = new File(path);
        path = file.getCanonicalPath();

        if (path.contains("DatabaseCreator")) {
            path = "../../DB.sql";
            file = new File(path);
        }
        file.delete();

        Class.forName("org.sqlite.JDBC");
        c = DriverManager.getConnection("jdbc:sqlite:" + path);
        c.setAutoCommit(false);
    }

    private void builtData() throws Exception {
        stmt = c.createStatement();
        String sql = "CREATE TABLE USER "
                + "(ID              INT     PRIMARY KEY     NOT NULL,"
                + " NAME            CHAR(15)                NOT NULL, "
                + " PASSWORD        CHAR(15)                NOT NULL, "
                + " ROLE            INT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE MAIN "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " CATEGORY       INT                      , "
                + " SUBCATEGORY    INT                      , "
                + " MANUFACTURER   INT                      , "
                + " EDITOR         INT                      NOT NULL, "
                + " STATUS         INT                      NOT NULL, "
                + " TITLE          TEXT                     , "
                + " URL            TEXT                     , "
                + " NAME           TEXT                     , "
                + " DATE           TEXT                     NOT NULL, "
                + " LAST_EDIT      TEXT                     NOT NULL, "
                + " VIEWS          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE CONTENT_GPU "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " TEST           TEXT                     NOT NULL, "
                + " TEST2          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE CONTENT_CPU "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " TEST           TEXT                     NOT NULL, "
                + " TEST2          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE CONTENT_RAM "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " TEST           TEXT                     NOT NULL, "
                + " TEST2          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE CATEGORY "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " NAME           TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE SUBCATEGORY "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " NAME           TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE MANUFACTURER "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " NAME           TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE SEARCH "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " MAINID         INT                      NOT NULL, "
                + " TAGID          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE TAG "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " NAME           TEXT                     NOT NULL, "
                + " VIEWS          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE WISHLIST "
                + "(ID             INT      PRIMARY KEY     NOT NULL,"
                + " USERID         INT                      NOT NULL, "
                + " MAINID         INT                      NOT NULL)";
        stmt.executeUpdate(sql);
    }

    private void initStartContent() throws Exception {
        stmt = c.createStatement();
        String sql = "INSERT INTO USER (ID,NAME,PASSWORD,ROLE) "
                + "VALUES (1, 'Admin', 'root', 1);";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "INSERT INTO MAIN (ID,CATEGORY,SUBCATEGORY,MANUFACTURER,EDITOR,STATUS,TITLE,URL,NAME,DATE,LAST_EDIT,VIEWS) "
                + "VALUES (1, 15, 0, 10, 1, 0, 'Test1', '/test1', 'Test Entry 1', '15-11-04', '15-11-04-00-11', 0);";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "INSERT INTO MAIN (ID,CATEGORY,SUBCATEGORY,MANUFACTURER,EDITOR,STATUS,TITLE,URL,NAME,DATE,LAST_EDIT,VIEWS) "
                + "VALUES (2, 8, 0, 10, 1, 0, 'Test2', '/test2', 'Test Entry 2', '15-11-04', '15-11-04-00-11', 0);";
        stmt.executeUpdate(sql);
    }

    public static void main(String args[]) {
        try {
            DatabaseCreator creator = new DatabaseCreator();
            creator.builtData();
            creator.initStartContent();
            stmt.close();
            c.commit();
            c.close();
            System.out.println("Database successfully created.");
        } catch (Exception e) {
            Logger.getLogger(DatabaseCreator.class.getName()).log(Level.SEVERE, e.getMessage());
        }
    }
}
