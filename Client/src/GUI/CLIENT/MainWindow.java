package GUI.CLIENT;

import GUI.WindowObject;
import Main.ClientManager;
import java.awt.event.ActionEvent;
import javax.swing.JFrame;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.SwingConstants;

public class MainWindow extends WindowObject {

    public MainWindow(JFrame frame) {
        super(frame, "MainWindow");
    }

    @Override
    public void initStructure() {
        JMenuBar menubar = new JMenuBar();

        JMenuItem search = new JMenuItem("Search");
        search.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "SearchWindow");
        });
        search.setHorizontalAlignment(SwingConstants.CENTER);
        
        JMenuItem editor = new JMenuItem("Editor");
        editor.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "EditorWindow");
        });
        editor.setHorizontalAlignment(SwingConstants.CENTER);

        JMenuItem tags = new JMenuItem("TagsWindow");
        tags.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "TagsWindow");
        });
        tags.setHorizontalAlignment(SwingConstants.CENTER);

        JMenuItem userlist = new JMenuItem("Userlist");
        userlist.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "UserlistWindow");
        });
        userlist.setHorizontalAlignment(SwingConstants.CENTER);

        JMenuItem category = new JMenuItem("Category");
        category.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "CategoryWindow");
        });
        category.setHorizontalAlignment(SwingConstants.CENTER);

        JMenuItem subCategory = new JMenuItem("SubCategory");
        subCategory.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "SubCategoryWindow");
        });
        subCategory.setHorizontalAlignment(SwingConstants.CENTER);

        JMenuItem manufacturer = new JMenuItem("Manufacturer");
        manufacturer.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("toggleVisibility", "", "ManufacturerWindow");
        });
        manufacturer.setHorizontalAlignment(SwingConstants.CENTER);

        menubar.add(search);
        menubar.add(editor);
        menubar.add(tags);
        menubar.add(userlist);
        menubar.add(category);
        menubar.add(subCategory);
        menubar.add(manufacturer);

        frame.setJMenuBar(menubar);
    }
}
