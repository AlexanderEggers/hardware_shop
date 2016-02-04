package Main;

import GUI.WindowController;
import Input.ClientInput;
import java.sql.Connection;
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
    public static ClientInput g_input;

    public void initClient(JFrame frame) {
        g_input = new ClientInput();
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
