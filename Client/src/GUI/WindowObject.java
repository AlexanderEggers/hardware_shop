package GUI;

import javax.swing.JFrame;
import javax.swing.JPanel;

public abstract class WindowObject {

    protected JFrame frame;
    protected final JPanel referencePanel;
    private final String windowName;

    public WindowObject(JFrame frame, String windowName) {
        this.frame = frame;
        this.windowName = windowName;

        referencePanel = new JPanel();
        referencePanel.setSize(frame.getWidth(), frame.getHeight());
        frame.add(referencePanel);
    }

    public void initStructure() {
    }

    public void internalMethod(String event) {
    }

    public JPanel getReferencePanel() {
        return referencePanel;
    }

    public String getWindowName() {
        return windowName;
    }
}
