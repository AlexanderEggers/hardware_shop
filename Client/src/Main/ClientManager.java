package Main;

import GUI.WindowController;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JFrame;

/**
 * Diese Klasse wird die unterschiedlichen primären Objekte vom Client halten
 * und global zugreifbar machen.
 */
public class ClientManager {

    public static Connection g_dbConnection;
    public static Statement g_stmt;
    public static WindowController g_guiController;

    public void initClient(JFrame frame) {
        try {
            Class.forName("org.sqlite.JDBC");
            g_dbConnection = DriverManager.getConnection("jdbc:sqlite:..//DB.sql");
            g_dbConnection.setAutoCommit(false);
        } catch (ClassNotFoundException | SQLException e) {
        }

        g_guiController = new WindowController(frame);
        ClientManager.g_guiController.windowControl("toggleVisibility", "", "SearchWindow");
    }

    public static void exitClient() {
        try {
            g_stmt.close();
            g_dbConnection.close();
        } catch (Exception e) {
        }
    }
}
