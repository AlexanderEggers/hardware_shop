package Input;

import GUI.LOGIN.ClientLoginWindow;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class LoginInput extends KeyAdapter {

    @Override
    public void keyTyped(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ENTER) {
            ClientLoginWindow.CLICK_LOGINBUTTON();
        }
    }

    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ENTER) {
            ClientLoginWindow.CLICK_LOGINBUTTON();
        }
    }
}
