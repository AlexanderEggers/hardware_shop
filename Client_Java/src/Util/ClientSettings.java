package Util;

import Main.ClientFrame;
import Main.ClientManager;

public class ClientSettings {

    public enum ClientState {

        LOGIN, CLIENT
    }
    public static ClientState currentState = ClientState.LOGIN;

    public static ClientFrame clientFrame;
    public static ClientManager clientManager;
    public static String inputUser;
}
