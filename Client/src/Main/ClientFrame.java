package Main;

import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;

public class ClientFrame extends JFrame {

    public void startFrame() {
        setTitle("Hardware Shop - Client");
        setSize(1200, 800);
        setVisible(true);
        setResizable(true);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
    }
}
