package GUI.CLIENT;

import GUI.WindowObject;
import Main.ClientManager;
import java.awt.FlowLayout;
import java.util.ArrayList;
import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class SearchWindow extends WindowObject {

    public static JLabel label;
    public static JPanel entryDisplay;
    public static ArrayList<JLabel> labelList;
    
    public SearchWindow(JFrame frame) {
        super(frame, "SearchWindow");
        
        labelList = new ArrayList<>();
    }

    @Override
    public void initStructure() {
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));
        
        JPanel filterMenu = new JPanel();
        filterMenu.setLayout(new BoxLayout(filterMenu, BoxLayout.X_AXIS));
        
        JPanel filterMenu1 = new JPanel();
        filterMenu1.setLayout(new BoxLayout(filterMenu1, BoxLayout.Y_AXIS));
        
        JPanel innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        JTextField textField = new JTextField(20);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        innerPanel.add(textField);
        
        filterMenu1.add(innerPanel);
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        label = new JLabel("Das ist ein Test.");
        innerPanel.add(label);
        
        filterMenu1.add(innerPanel);
        
        
        JPanel filterMenu2 = new JPanel();
        filterMenu2.setLayout(new BoxLayout(filterMenu2, BoxLayout.Y_AXIS));
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        textField = new JTextField(20);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        innerPanel.add(textField);
        
        filterMenu2.add(innerPanel);
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        JLabel labeltest = new JLabel("Das ist ein Test.");
        innerPanel.add(labeltest);
        
        filterMenu2.add(innerPanel);
        
        
        
        JPanel filterMenu3 = new JPanel();
        filterMenu3.setLayout(new BoxLayout(filterMenu3, BoxLayout.Y_AXIS));
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        textField = new JTextField(20);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        innerPanel.add(textField);
        
        filterMenu3.add(innerPanel);
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        labeltest = new JLabel("Das ist ein Test.");
        innerPanel.add(labeltest);

        filterMenu3.add(innerPanel);
        
        
        JPanel filterMenu4 = new JPanel();
        filterMenu4.setLayout(new BoxLayout(filterMenu4, BoxLayout.Y_AXIS));
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        textField = new JTextField(20);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        innerPanel.add(textField);
        
        filterMenu4.add(innerPanel);
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        labeltest = new JLabel("Das ist ein Test.");
        innerPanel.add(labeltest);

        filterMenu4.add(innerPanel);
        
        
        
        JPanel filterMenu5 = new JPanel();
        filterMenu5.setLayout(new BoxLayout(filterMenu5, BoxLayout.Y_AXIS));
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        textField = new JTextField(20);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        innerPanel.add(textField);
        
        filterMenu5.add(innerPanel);
        
        innerPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        labeltest = new JLabel("Das ist ein Test.");
        innerPanel.add(labeltest);

        filterMenu5.add(innerPanel);
        
        
        filterMenu.add(filterMenu1);
        filterMenu.add(filterMenu2);
        filterMenu.add(filterMenu3);
        filterMenu.add(filterMenu4);
        filterMenu.add(filterMenu5);
        
        
        entryDisplay = new JPanel();
        entryDisplay.setLayout(new BoxLayout(entryDisplay, BoxLayout.Y_AXIS));
        
        JPanel titlepanel = new JPanel();
        titlepanel.setLayout(new BoxLayout(titlepanel, BoxLayout.X_AXIS));
        
        JPanel innerpanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        JLabel entryLabel = new JLabel("ID");
        innerpanel.add(entryLabel);
        titlepanel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        entryLabel = new JLabel("Category");
        innerpanel.add(entryLabel);
        titlepanel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        entryLabel = new JLabel("Sub-Category");
        innerpanel.add(entryLabel);
        titlepanel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        entryLabel = new JLabel("Editor");
        innerpanel.add(entryLabel);
        titlepanel.add(innerpanel);
        
        entryDisplay.add(new JPanel()).setSize(entryDisplay.getWidth(), 10);
        entryDisplay.add(titlepanel);
        entryDisplay.add(new JPanel()).setSize(entryDisplay.getWidth(), 10);
        
        addEntry();
        
        panel.add(filterMenu);
        panel.add(entryDisplay);
        
        referencePanel.add(panel);
    }
    
    public static void addEntry() {
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.X_AXIS));
        
        JPanel innerpanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 5, 5));
        JLabel entryLabel = new JLabel();
        innerpanel.add(entryLabel);
        labelList.add(entryLabel);
        panel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 5, 5));
        entryLabel = new JLabel();
        innerpanel.add(entryLabel);
        labelList.add(entryLabel);
        panel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 5, 5));
        entryLabel = new JLabel();
        innerpanel.add(entryLabel);
        labelList.add(entryLabel);
        panel.add(innerpanel);
        
        innerpanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 5, 5));
        entryLabel = new JLabel();
        innerpanel.add(entryLabel);
        labelList.add(entryLabel);
        panel.add(innerpanel);
        
        entryDisplay.add(panel);
    }
}
