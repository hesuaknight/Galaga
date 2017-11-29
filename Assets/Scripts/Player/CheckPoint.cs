using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint {

    private Vector3 _position;
    private Weapon _weapon;

    public CheckPoint(Vector3 position, Weapon weapon) {
        SetCheckPoint(position, weapon);
    }

    public void SetCheckPoint(Vector3 position, Weapon weapon) {
        _position = position;
        _weapon = weapon;
        Debug.Log("Saved!");
    }

    public void LoadCheckPoint(Player player) {
        player.transform.position = _position;
        player.weapon = _weapon;
        Debug.Log("Loaded!");
    }
}
