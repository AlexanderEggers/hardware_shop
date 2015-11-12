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
        if(e.getActionCommand().equalsIgnoreCase("ButtonSearch")) {
            executeTest();
        }
    }

    private void executeTest() {
        JTextField textField = SearchWindow.searchInput;
        String inputCategory;
        
//        if(SearchWindow.categoryField.getText() != null 
//                && !SearchWindow.categoryField.getText().equalsIgnoreCase("")) {
//            inputCategory = SearchWindow.categoryField.getText();
//        } else {
//            inputCategory = "ID";
//        }
        
        inputCategory = "ID";
        
        try {
            ClientManager.g_stmt = ClientManager.g_dbConnection.createStatement();

            ResultSet rs = ClientManager.g_stmt.executeQuery("SELECT ID,CATEGORY,SUBCATEGORY,EDITOR FROM MAIN "
                    + "WHERE " + inputCategory + " = " + textField.getText() + " ;");

            /**
             * Adding/Deleting list objects and it's content dynamicly to the
             * search window based on the content which has been found
             */
            while (rs.next()) {
                ArrayList<Integer> content = new ArrayList<>();
                content.add(rs.getInt("ID"));
                content.add(rs.getInt("CATEGORY"));
                content.add(rs.getInt("SUBCATEGORY"));
                content.add(rs.getInt("EDITOR"));

                /**
                 * Resets all list objects at the search window
                 */
                if (!SearchWindow.labelList.isEmpty()) {
                    SearchWindow.labelList.get(0).getParent().getParent().removeAll();
                    SearchWindow.labelList.clear();
                }

                /**
                 * Creates new list objects
                 */
                for (int i = 0; i < content.size() / 4; i++) {
                    SearchWindow.addEntry();
                }

                /**
                 * Adds content to the list objects
                 */
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
