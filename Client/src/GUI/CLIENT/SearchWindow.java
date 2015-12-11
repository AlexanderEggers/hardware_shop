package GUI.CLIENT;

import Util.ContentTableRenderer;
import GUI.WindowObject;
import Main.ClientManager;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.Properties;
import javax.swing.*;
import static javax.swing.ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED;
import static javax.swing.ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS;
import javax.swing.table.DefaultTableModel;
import org.jdatepicker.impl.DateComponentFormatter;
import org.jdatepicker.impl.JDatePanelImpl;
import org.jdatepicker.impl.JDatePickerImpl;
import org.jdatepicker.impl.UtilDateModel;

public class SearchWindow extends WindowObject {

    public static JPanel entryDisplay;
    public static JTextField searchInput;
    public static ArrayList<JLabel> labelList;
    public static DefaultTableModel contentList;

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
        searchInput = new JTextField(15);
        searchInput.setName("TextFieldSearch");
        searchInput.addKeyListener(ClientManager.g_input);
        search.add(searchInput);
        JButton button = new JButton("Search");
        button.setActionCommand("ButtonSearch");
        button.addActionListener(ClientManager.g_input);
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

        contentList = new DefaultTableModel() {

            @Override
            public boolean isCellEditable(int row, int column) {
                return false;
            }
        };

        JTable table = new JTable(contentList);
        table.addMouseListener(new MouseAdapter() {

            @Override
            public void mouseClicked(MouseEvent e) {
                if (e.getClickCount() == 2) {
                    System.out.println("Click");
                    //hier müsste der Editor aufgerufen werden
                }
            }
        });
        table.setDefaultRenderer(Object.class, new ContentTableRenderer());

        contentList.addColumn("ID");
        contentList.addColumn("Category");
        contentList.addColumn("SubCategory");
        contentList.addColumn("Editor");

        JScrollPane scrollArea = new JScrollPane(table, VERTICAL_SCROLLBAR_ALWAYS, HORIZONTAL_SCROLLBAR_AS_NEEDED);
        scrollArea.setPreferredSize(new Dimension(450, 570));

        entryDisplay.add(Box.createVerticalStrut(20));
        entryDisplay.add(scrollArea);

        return entryDisplay;
    }
}
