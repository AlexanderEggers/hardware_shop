package Main;

import Util.ClientSettings;
import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;

public class ClientFrame extends JFrame {

    public ClientFrame() {
        setTitle("Hardware Shop - Client");
        setSize(1200, 800);
        setVisible(true);
        setResizable(true);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        ClientSettings.clientManager = new ClientManager();
        ClientSettings.clientManager.initClient(ClientFrame.this);
    }

    @Override
    public void dispose() {
        ClientManager.exitClient();
        super.dispose();
    }
}
