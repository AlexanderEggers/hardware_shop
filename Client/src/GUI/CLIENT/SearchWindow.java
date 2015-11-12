package GUI.CLIENT;

import GUI.WindowObject;
import Main.ClientManager;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.Robot;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.Properties;
import javax.swing.*;
import org.jdatepicker.impl.DateComponentFormatter;
import org.jdatepicker.impl.JDatePanelImpl;
import org.jdatepicker.impl.JDatePickerImpl;
import org.jdatepicker.impl.UtilDateModel;

public class SearchWindow extends WindowObject {

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

        JPanel filterMenu = new JPanel(new FlowLayout(FlowLayout.LEFT, 50, 0));

        
        //Filter Menu 1 - beinhaltet Suche, Status und Ersteller
        JPanel filterMenu1 = new JPanel();
        filterMenu1.setLayout(new BoxLayout(filterMenu1, BoxLayout.Y_AXIS));

        JPanel search = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JTextField textField = new JTextField(15);
        textField.setName("TextFieldSearch");
        textField.addKeyListener(ClientManager.g_input);
        search.add(textField);
        JButton button = new JButton("Search");
        button.setName("TextFieldSearch");
        button.addActionListener((ActionEvent ae) -> {
            try {
                //Simulate enter key at textfield
            } catch (Exception e) {
            }
        });
        search.add(button);
        filterMenu1.add(search);

        filterMenu1.add(Box.createVerticalStrut(5));

        JPanel editor = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel editorDef = new JLabel("Editor: ");
        editor.add(editorDef);
        editor.add(Box.createHorizontalStrut(0));
        JComboBox editorChooser = new JComboBox();
        editorChooser.addItem("Admin"); //Nur um die DropBox zu testen aktuell
        editor.add(editorChooser);
        filterMenu1.add(editor);

        filterMenu1.add(Box.createVerticalStrut(5));

        JPanel status = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel statusDef = new JLabel("Status: ");
        status.add(statusDef);
        JComboBox statusChooser = new JComboBox();
        statusChooser.addItem("Veröffentlicht"); //Nur um die DropBox zu testen
        statusChooser.addItem("Zur Kontrolle");
        statusChooser.addItem("In Arbeit");
        status.add(statusChooser);
        filterMenu1.add(status);

        
        //Filter Menu 2 - beinhaltet Kategorie, SubKategorie und Hersteller
        JPanel filterMenu2 = new JPanel();
        filterMenu2.setLayout(new BoxLayout(filterMenu2, BoxLayout.Y_AXIS));

        JPanel category = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel categoryDef = new JLabel("Category: ");
        category.add(categoryDef);
        category.add(Box.createHorizontalStrut(21));
        JComboBox categoryChooser = new JComboBox();
        categoryChooser.addItem("CPU"); //Nur um die DropBox zu testen aktuell
        category.add(categoryChooser);
        filterMenu2.add(category);

        filterMenu2.add(Box.createVerticalStrut(5));

        JPanel subCategory = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel subCategoryDef = new JLabel("SubCategory: ");
        subCategory.add(subCategoryDef);
        subCategory.add(Box.createHorizontalStrut(-1));
        JComboBox subCategoryChooser = new JComboBox();
        subCategoryChooser.addItem("Desktop-PC"); //Nur um die DropBox zu testen
        subCategory.add(subCategoryChooser);
        filterMenu2.add(subCategory);

        filterMenu2.add(Box.createVerticalStrut(5));

        JPanel manufacturer = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel manufacturerDef = new JLabel("Manufacturer: ");
        manufacturer.add(manufacturerDef);
        JComboBox manufacturerChooser = new JComboBox();
        manufacturerChooser.addItem("Intel"); //Nur um die DropBox zu testen
        manufacturerChooser.addItem("AMD");
        manufacturer.add(manufacturerChooser);
        filterMenu2.add(manufacturer);

        
        //Filter Menu 3 - beinhaltet Datum, Last_Edit
        JPanel filterMenu3 = new JPanel();
        filterMenu3.setLayout(new BoxLayout(filterMenu3, BoxLayout.Y_AXIS));

        JPanel date = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel dateDef = new JLabel("Datum: ");
        date.add(dateDef);
        date.add(Box.createHorizontalStrut(17));
        UtilDateModel model = new UtilDateModel();
        JDatePanelImpl datePanel = new JDatePanelImpl(model, new Properties());
        JDatePickerImpl datePicker = new JDatePickerImpl(datePanel, new DateComponentFormatter());
        date.add(datePicker);
        filterMenu3.add(date);
        
        filterMenu3.add(Box.createVerticalStrut(5));
        
        JPanel lastDate = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel lastDateDef = new JLabel("Bearbeitet: ");
        lastDate.add(lastDateDef);
        UtilDateModel lastDateModel = new UtilDateModel();
        JDatePanelImpl lastDatePanel = new JDatePanelImpl(lastDateModel, new Properties());
        JDatePickerImpl lastDatePicker = new JDatePickerImpl(lastDatePanel, new DateComponentFormatter());
        lastDatePicker.setSize(20, 10);
        lastDate.add(lastDatePicker);
        filterMenu3.add(lastDate);
        
        filterMenu3.add(Box.createVerticalStrut(40));

        
        //Filter Menu 4 - beinhaltet LIMIT, SORT AUSWAHL, SORT Ausrichtung
        JPanel filterMenu4 = new JPanel();
        filterMenu4.setLayout(new BoxLayout(filterMenu4, BoxLayout.Y_AXIS));

        JPanel limit = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel limitDef = new JLabel("Max. Ergebnisse: ");
        limit.add(limitDef);
        JTextField limitField = new JTextField(2);
        limit.add(limitField);
        filterMenu4.add(limit);

        filterMenu4.add(Box.createVerticalStrut(5));

        JPanel sort = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel sortDef = new JLabel("Sort by: ");
        sort.add(sortDef);
        sort.add(Box.createHorizontalStrut(50));
        JComboBox sortChooser = new JComboBox();
        sortChooser.addItem("Views"); //Nur um die DropBox zu testen
        sortChooser.addItem("ID"); //Nur um die DropBox zu testen
        sort.add(sortChooser);
        filterMenu4.add(sort);

        filterMenu4.add(Box.createVerticalStrut(5));

        JPanel sortDirc = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel sortDircDef = new JLabel("Sortierung: ");
        sortDirc.add(sortDircDef);
        sortDirc.add(Box.createHorizontalStrut(28));
        JCheckBox sortCheckBox = new JCheckBox();
        sortDirc.add(sortCheckBox);
        filterMenu4.add(sortDirc);

        
        filterMenu.add(filterMenu1);
        filterMenu.add(filterMenu2);
        filterMenu.add(filterMenu3);
        filterMenu.add(filterMenu4);


        panel.add(filterMenu);
        panel.add(addEntryArea());
        referencePanel.add(panel);
    }

    private Component addEntryArea() {
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

        entryDisplay.add(Box.createVerticalStrut(20));
        entryDisplay.add(titlepanel);
        entryDisplay.add(Box.createVerticalStrut(20));

        return entryDisplay;
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
