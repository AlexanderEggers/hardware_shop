package GUI.LOGIN;

import GUI.WindowObject;
import Main.ClientFrame;
import Input.LoginInput;
import Main.ClientManager;
import Util.ClientSettings;
import Util.ClientSettings.ClientState;
import java.awt.FlowLayout;
import java.awt.HeadlessException;
import java.awt.event.ActionEvent;
import java.io.File;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

public class LoginWindow extends WindowObject {

    private JTextField userField;
    private JPasswordField passwordField;
    private static JButton button;
    private final LoginInput input;

    public LoginWindow(JFrame frame) {
        super(frame, "LoginWindow");
        input = new LoginInput();
    }

    @Override
    public void initStructure() {
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));

        JPanel titlePanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        titlePanel.add(new JLabel("LOGIN"));
        panel.add(titlePanel);

        JPanel userPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel label = new JLabel("User:");
        label.setBorder(new EmptyBorder(0, 0, 0, 34));
        userField = new JTextField(8);
        userField.addKeyListener(input);
        userPanel.add(label);
        userPanel.add(userField);
        panel.add(userPanel);

        JPanel passwordPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        passwordPanel.setBorder(new EmptyBorder(0, 0, 10, 0));
        label = new JLabel("Password:");
        label.setBorder(new EmptyBorder(0, 0, 0, 3));
        passwordField = new JPasswordField(8);
        passwordField.addKeyListener(input);
        passwordPanel.add(label);
        passwordPanel.add(passwordField);
        panel.add(passwordPanel);

        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        button = new JButton("Ok");
        button.addKeyListener(input);
        button.addActionListener((ActionEvent ae) -> {
            try {
                Class.forName("org.sqlite.JDBC");

                String path = "../DB.sql";
                File file = new File(path);
                if (!file.exists()) {
                    path = "../../DB.sql";
                }

                ClientManager.g_dbConnection = DriverManager.getConnection("jdbc:sqlite:" + path);
                ClientManager.g_dbConnection.setAutoCommit(false);
                ClientManager.g_stmt = ClientManager.g_dbConnection.createStatement();
                ResultSet rs = ClientManager.g_stmt.executeQuery("SELECT ROLE,PASSWORD FROM USER WHERE USERNAME = '"
                        + userField.getText() + "';");
                if (!rs.next()) {
                    JOptionPane.showMessageDialog(frame,
                            "Invalid input. Try again.",
                            "Error Message", JOptionPane.ERROR_MESSAGE);
                } else {
                    do {
                        int role = rs.getInt("ROLE");
                        String password = rs.getString("PASSWORD");
                        String typedPassWord = new String(passwordField.getPassword());

                        if (role == 1 && password.equalsIgnoreCase(typedPassWord)) {
                            frame.dispose();
                            ClientSettings.currentState = ClientState.CLIENT;
                            ClientSettings.inputUser = userField.getText();
                            ClientSettings.clientFrame = new ClientFrame();
                        } else {
                            JOptionPane.showMessageDialog(frame,
                                    "Invalid input. Try again.",
                                    "Error Message", JOptionPane.ERROR_MESSAGE);
                        }
                    } while (rs.next());
                }
                rs.close();
            } catch (ClassNotFoundException | SQLException | HeadlessException ex) {
                System.out.println("Irgendetwas ist falsch gelaufen." + ex.getMessage());
            }
        });
        buttonPanel.add(button);
        panel.add(buttonPanel);
        referencePanel.add(panel);
    }

    public static void CLICK_LOGINBUTTON() {
        button.doClick();
    }
}
