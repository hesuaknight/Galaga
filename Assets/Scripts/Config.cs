using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    private static Config _instance;
    public static Config instance {get { return _instance; } }

    public List<Player> players;

    public EKeyController playerControl;

    private void Awake() {
        if (!_instance)
            _instance = this;
        else
            Destroy(gameObject);
        SetPlayerController();
    }

    private void SetPlayerController() {
        if(players.Count == 2) {
            players[0].controller = new KeyboardCtrl(players[0]);
            players[1].controller = new MouseCtrl(players[1]);
        }else {
            if(playerControl == EKeyController.Keyboard)
                players[0].controller = new KeyboardCtrl(players[0]);
            else
                players[0].controller = new MouseCtrl(players[0]);
        }
    }
}

public enum EKeyController {
    Keyboard,
    Mouse
}
