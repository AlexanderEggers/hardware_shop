package Input;

import GUI.CLIENT.SearchWindow;
import Main.ClientManager;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.JTextField;

public class ClientInput extends KeyAdapter implements ActionListener {

    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ENTER
                && e.getComponent().getName().equalsIgnoreCase("TextFieldSearch")) {
            executeTest();
        }
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getActionCommand().equalsIgnoreCase("ButtonSearch")) {
            executeTest();
        }
    }

    private void executeTest() {
        JTextField textField = SearchWindow.searchInput;
        String inputCategory;

        if (textField.getText().isEmpty()) {
            return;
        }

//        if(SearchWindow.categoryField.getText() != null 
//                && !SearchWindow.categoryField.getText().equalsIgnoreCase("")) {
//            inputCategory = SearchWindow.categoryField.getText();
//        } else {
//            inputCategory = "ID";
//        }
        inputCategory = "MAIN.ID"; //aktuell nur zum testen

        try {
            ClientManager.g_stmt = ClientManager.g_dbConnection.createStatement();

            ResultSet rs = ClientManager.g_stmt.executeQuery("SELECT MAIN.ID,CATEGORY_NAME,SUBCATEGORY_NAME,USERNAME FROM MAIN "
                    + "INNER JOIN CATEGORY ON MAIN.CATEGORY = CATEGORY.ID "
                    + "INNER JOIN SUBCATEGORY ON MAIN.SUBCATEGORY = SUBCATEGORY.ID "
                    + "INNER JOIN USER ON MAIN.EDITOR = USER.ID "
                    + "WHERE " + inputCategory + " = " + textField.getText() + ";");
            /**
             * SELECT name FROM MAIN LEFT JOIN category USING(ID)
             */

            /**
             * Adding/Deleting list objects and it's content dynamicly to the
             * search window based on the content which has been found
             */
            while (rs.next()) {
                ArrayList<String> content = new ArrayList<>();
                content.add(rs.getInt("ID") + "");
                content.add(rs.getString("CATEGORY_NAME"));
                content.add(rs.getString("SUBCATEGORY_NAME"));
                content.add(rs.getString("USERNAME"));

                /**
                 * Resets all list objects at the search window
                 */
                for (int i = 0; i < SearchWindow.contentList.getRowCount(); i++) {
                    SearchWindow.contentList.removeRow(i);
                }

                /**
                 * Adds content to the list objects
                 */
                for (int i = 0; i < content.size(); i += 4) {
                    SearchWindow.contentList.addRow(new Object[]{
                        content.get(i),
                        content.get(i + 1),
                        content.get(i + 2),
                        content.get(i + 3)
                    });
                }
            }
            rs.close();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
