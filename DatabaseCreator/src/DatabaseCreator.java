
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
        String sql = "CREATE TABLE user "
                + "(id              INT     PRIMARY KEY     NOT NULL,"
                + " username        CHAR(15)                NOT NULL, "
                + " password        CHAR(15)                NOT NULL, "
                + " role            INT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE main "
                + "(id             INT      PRIMARY KEY     NOT NULL,"
                + " category       INT                      , "
                + " subcategory    INT                      , "
                + " manufacturer   INT                      , "
                + " editor         INT                      NOT NULL, "
                + " status         INT                      NOT NULL, "
                + " title          TEXT                     , "
                + " url            TEXT                     , "
                + " name           TEXT                     , "
                + " date           TEXT                     NOT NULL, "
                + " last_edit      TEXT                     NOT NULL, "
                + " views          INT                      NOT NULL)";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "CREATE TABLE content_access "
                + "(id             INT      PRIMARY KEY     NOT NULL,"
                + " access         INT                              )";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE content_GPU "
                + "(id             INT      PRIMARY KEY     NOT NULL,"
                + " test           TEXT                     NOT NULL, "
                + " test2          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE content_CPU "
                + "(id                INT      PRIMARY KEY     NOT NULL,"
                + " test              TEXT                     NOT NULL, "
                + " test2             INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE content_RAM "
                + "(id                INT      PRIMARY KEY     NOT NULL,"
                + " test              TEXT                     NOT NULL, "
                + " test2             INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE category "
                + "(id                INT      PRIMARY KEY     NOT NULL,"
                + " category_name     TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE subcategory "
                + "(id                INT      PRIMARY KEY     NOT NULL,"
                + " subcategory_name  TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE manufacturer "
                + "(id                  INT      PRIMARY KEY     NOT NULL,"
                + " manufacturer_ name  TEXT                     NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE search "
                + "(id              INT      PRIMARY KEY     NOT NULL,"
                + " main_id         INT                      NOT NULL, "
                + " tag_id          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE tag "
                + "(id             INT      PRIMARY KEY     NOT NULL,"
                + " name           TEXT                     NOT NULL, "
                + " views          INT                      NOT NULL)";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "CREATE TABLE wishlist "
                + "(id              INT      PRIMARY KEY     NOT NULL,"
                + " user_id         INT                      NOT NULL, "
                + " main_id         INT                      NOT NULL)";
        stmt.executeUpdate(sql);
    }

    private void initStartContent() throws Exception {
        stmt = c.createStatement();
        String sql = "INSERT INTO user (id,username,password,role) "
                + "VALUES (1, 'Admin', 'root', 1);";
        stmt.executeUpdate(sql);

        stmt = c.createStatement();
        sql = "INSERT INTO main (id,category,subcategory,manufacturer,editor,status,title,url,name,date,last_edit,views) "
                + "VALUES (0, 0, 0, 10, 1, 0, 'Test1', '/test1', 'Test Entry 1', '15-11-04', '15-11-04-00-11', 0);";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "INSERT INTO main (id,category,subcategory,manufacturer,editor,status,title,url,name,date,last_edit,views) "
                + "VALUES (1, 1, 0, 10, 1, 0, 'Test2', '/test2', 'Test Entry 2', '15-11-04', '15-11-04-00-11', 0);";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "INSERT INTO category (id,category_name) "
                + "VALUES (0, 'Category0');";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "INSERT INTO category (id,category_name) "
                + "VALUES (1, 'Category1');";
        stmt.executeUpdate(sql);
        
        stmt = c.createStatement();
        sql = "INSERT INTO subcategory (id,subcategory_name) "
                + "VALUES (0, 'SubCategory0');";
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
