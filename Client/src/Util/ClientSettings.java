package Util;

import Main.ClientFrame;

public class ClientSettings {

    public enum ClientState {

        LOGIN, CLIENT
    }
    public static ClientState currentState = ClientState.LOGIN;

    public static ClientFrame clientFrame;
    public static String inputUser;
}
