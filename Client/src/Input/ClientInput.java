package Input;

import GUI.CLIENT.SearchWindow;
import Main.ClientManager;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.sql.ResultSet;
import java.util.ArrayList;
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

            ResultSet rs = ClientManager.g_stmt.executeQuery("SELECT ID,CATEGORY,SUBCATEGORY,EDITOR FROM MAIN "
                    + "WHERE ID = " + textField.getText() + " ;");

            while (rs.next()) {
                ArrayList<Integer> content = new ArrayList<>();
                content.add(rs.getInt("ID"));
                content.add(rs.getInt("CATEGORY"));
                content.add(rs.getInt("SUBCATEGORY"));
                content.add(rs.getInt("EDITOR"));

                for (int i = 0; i < content.size(); i++) {
                    if (i < SearchWindow.labelList.size()) {
                        SearchWindow.labelList.get(i).setText(content.get(i) + "");
                    } else {
                        break;
                    }
                }
            }

            rs.close();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
