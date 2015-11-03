package GUI;

import GUI.CLIENT.MainWindow;
import GUI.CLIENT.SearchWindow;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;

public class WindowController {

    private final HashMap<String, WindowObject> windowMap;
    private final ArrayList<WindowObject> windowList;
    private String activeWindowName;
    private WindowObject activeWindowObject;

    public WindowController(JFrame frame) {
        windowMap = new HashMap<>();
        windowList = new ArrayList<>();

        addWindowObject("MainWindow", new MainWindow(frame));
        addWindowObject("SearchWindow", new SearchWindow(frame));

        initController();
    }

    private void initController() {
        windowList.stream().forEach((window) -> {
            window.initStructure();
            window.getReferencePanel().setVisible(false);
        });
    }

    private void addWindowObject(String guiName, WindowObject gui) {
        windowMap.put(guiName, gui);
        windowList.add(gui);
    }

    public void windowControl(String event, String additionalData, String windowName) {
        WindowObject windowObject = windowMap.get(windowName);

        if (windowObject == null) {
            Logger.getLogger(WindowController.class.getName()).log(Level.SEVERE, "Window {0} not found.", windowName);
            return;
        }

        if (event.equalsIgnoreCase("toggleVisibility")) {
            if (windowName.equalsIgnoreCase(activeWindowName)) {
                windowObject.getReferencePanel().setVisible(false);
                windowObject.internalMethod("closeWindow");
                activeWindowName = "";
            } else {
                if (activeWindowObject != null) {
                    activeWindowObject.getReferencePanel().setVisible(false);
                    activeWindowObject.internalMethod("closeWindow");
                }
                windowObject.getReferencePanel().setVisible(true);
                windowObject.internalMethod("openWindow");
                activeWindowObject = windowObject;
                activeWindowName = windowName;
            }
        } else if (event.equalsIgnoreCase("internalMethod")) {
            windowObject.internalMethod(additionalData);
        }
    }
}
