package GUI.CLIENT;

import GUI.WindowObject;
import javax.swing.JFrame;
import javax.swing.JLabel;

public class SearchWindow extends WindowObject {

    public SearchWindow(JFrame frame) {
        super(frame, "SearchWindow");
    }

    @Override
    public void initStructure() {
        JLabel label = new JLabel("Das ist ein Test.");
        referencePanel.add(label);
    }
}
