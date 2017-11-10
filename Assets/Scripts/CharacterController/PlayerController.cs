using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController {

    protected KeyCode _fireAttack;
    public KeyCode fireKey { get { return _fireAttack; } }
    protected string _axisMovement;
    protected Player _ship;

    public PlayerController(Player ship) {
        _ship = ship;
    }

    public void Update() {
        _ship.Move(new Vector3(Input.GetAxis(_axisMovement), 0f, 0f));
    }
}
