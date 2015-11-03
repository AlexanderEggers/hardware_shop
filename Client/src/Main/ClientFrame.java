package Main;

import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;

public class ClientFrame {
    
    public static JFrame frame;
    
    public void startFrame() {
        frame = new JFrame("Hardware Shop - Client");
        frame.setSize(1200, 800);
        frame.setVisible(true);
        frame.setResizable(true);
        frame.setDefaultCloseOperation(EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null);
    }
}
