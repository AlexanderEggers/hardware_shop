package Main;

import GUI.LOGIN.LoginWindow;
import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;

public class ClientLogin extends JFrame {

    public ClientLogin(String title) {
        super(title);

        LoginWindow login = new LoginWindow(this);
        login.initStructure();
    }

    public static void main(String[] args) {
        ClientLogin frame = new ClientLogin("Login");
        frame.setSize(180, 180);
        frame.setResizable(false);
        frame.setDefaultCloseOperation(EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
