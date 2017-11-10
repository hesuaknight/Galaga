using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCtrl : PlayerController {
    public MouseCtrl(Player ship) : base(ship) {
        _axisMovement = "Mouse X";
        _fireAttack = KeyCode.Mouse0;
    }
}
