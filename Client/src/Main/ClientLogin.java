package Main;

import java.awt.FlowLayout;
import java.awt.HeadlessException;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

public class ClientLogin extends JFrame {

    public static JTextField INPUT_USER;
    private final JPasswordField passwordField;
    private static Connection c;
    private static Statement stmt;

    public ClientLogin(String title) {
        super(title);
        
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));

        JPanel titlePanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        titlePanel.add(new JLabel("LOGIN"));
        panel.add(titlePanel);

        JPanel userPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JLabel label = new JLabel("User:");
        label.setBorder(new EmptyBorder(0, 0, 0, 34));
        INPUT_USER = new JTextField(8);
        userPanel.add(label);
        userPanel.add(INPUT_USER);
        panel.add(userPanel);

        JPanel passwordPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        passwordPanel.setBorder(new EmptyBorder(0, 0, 10, 0));
        label = new JLabel("Password:");
        label.setBorder(new EmptyBorder(0, 0, 0, 3));
        passwordField = new JPasswordField(8);
        passwordPanel.add(label);
        passwordPanel.add(passwordField);
        panel.add(passwordPanel);

        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        JButton button = new JButton("Ok");
        button.addActionListener((ActionEvent ae) -> {
            try {
                Class.forName("org.sqlite.JDBC");
                c = DriverManager.getConnection("jdbc:sqlite:..//DB.sql");
                c.setAutoCommit(false);
                stmt = c.createStatement();
                ResultSet rs = stmt.executeQuery("SELECT ROLE,PASSWORD FROM USER WHERE NAME = '"
                        + INPUT_USER.getText() + "';");
                if (!rs.next()) {
                    JOptionPane.showMessageDialog(ClientLogin.this,
                            "Invalid input. Try again.",
                            "Error Message", JOptionPane.ERROR_MESSAGE);
                } else {
                    do {
                        int role = rs.getInt("ROLE");
                        String password = rs.getString("PASSWORD");
                        String typedPassWord = new String(passwordField.getPassword());

                        if (role == 1 && password.equalsIgnoreCase(typedPassWord)) {
                            System.out.println("DU WIRST EINGELOGGT! TBD");
                        } else {
                            JOptionPane.showMessageDialog(ClientLogin.this,
                                    "Invalid input. Try again.",
                                    "Error Message", JOptionPane.ERROR_MESSAGE);
                        }
                    } while (rs.next());
                }
                rs.close();
                stmt.close();
                c.close();
            } catch (ClassNotFoundException | SQLException | HeadlessException ex) {
                System.out.println("Irgendetwas ist falsch gelaufen." + ex.getMessage());
            }
        });
        buttonPanel.add(button);
        panel.add(buttonPanel);
        add(panel);
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
