using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCtrl : PlayerController {
    public KeyboardCtrl(Player ship) : base(ship) {
        _axisMovement = "Horizontal";
        _fireAttack = KeyCode.Space;
    }
}
