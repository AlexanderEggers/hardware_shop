package GUI.CLIENT;

import GUI.WindowObject;
import Main.ClientManager;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;

public class SearchWindow extends WindowObject {

    public static JLabel label;
    
    public SearchWindow(JFrame frame) {
        super(frame, "SearchWindow");
    }

    @Override
    public void initStructure() {
        JTextField textField = new JTextField(10);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        referencePanel.add(textField);
        
        label = new JLabel("Das ist ein Test.");
        referencePanel.add(label);
    }
}
