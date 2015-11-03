package Input;

import Main.ClientManager;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.sql.ResultSet;
import javax.swing.JTextField;

public class ClientInput extends KeyAdapter {

    @Override
    public void keyTyped(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ENTER
                && e.getComponent().getName().equalsIgnoreCase("TextFieldSearch")) {
            executeTest(e);
        }
    }

    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ENTER
                && e.getComponent().getName().equalsIgnoreCase("TextFieldSearch")) {
            executeTest(e);
        }
    }

    private void executeTest(KeyEvent e) {
        JTextField textField = (JTextField) e.getComponent();

        try {
            ClientManager.g_stmt = ClientManager.g_dbConnection.createStatement();

            ResultSet rs = ClientManager.g_stmt.executeQuery("SELECT CATEGORY FROM MAIN "
                    + "WHERE ID = " + textField.getText() + " ;");

            while (rs.next()) {
                System.out.println(rs.getInt("CATEGORY"));
            }

            rs.close();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
