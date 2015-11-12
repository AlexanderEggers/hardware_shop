package GUI.CLIENT;

import GUI.WindowObject;
import Main.ClientManager;
import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JMenuBar;
import javax.swing.SwingConstants;

public class MainWindow extends WindowObject {

    public MainWindow(JFrame frame) {
        super(frame, "MainWindow");
    }

    @Override
    public void initStructure() {
        JMenuBar menubar = new JMenuBar();

        JButton search = new JButton("Search");
        search.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "SearchWindow");
        });
        search.setHorizontalAlignment(SwingConstants.CENTER);
        
        JButton editor = new JButton("Editor");
        editor.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "EditorWindow");
        });
        editor.setHorizontalAlignment(SwingConstants.CENTER);

        JButton tags = new JButton("Tags");
        tags.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "TagsWindow");
        });
        tags.setHorizontalAlignment(SwingConstants.CENTER);

        JButton userlist = new JButton("Userlist");
        userlist.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "UserlistWindow");
        });
        userlist.setHorizontalAlignment(SwingConstants.CENTER);

        JButton category = new JButton("Category");
        category.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "CategoryWindow");
        });
        category.setHorizontalAlignment(SwingConstants.CENTER);

        JButton subCategory = new JButton("SubCategory");
        subCategory.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "SubCategoryWindow");
        });
        subCategory.setHorizontalAlignment(SwingConstants.CENTER);

        JButton manufacturer = new JButton("Manufacturer");
        manufacturer.addActionListener((ActionEvent e) -> {
            ClientManager.g_guiController.windowControl("showWindow", "", "ManufacturerWindow");
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
