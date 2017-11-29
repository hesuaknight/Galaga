using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComplex: Weapon {

    Weapon weapon1;
    Weapon weapon2;

    public WeaponComplex(Weapon w1, Weapon w2) {
        weapon1 = w1;
        weapon2 = w2;
        _fireCoolDown = Mathf.Min(weapon1.fireCoolDown, weapon2.fireCoolDown);
    }

    public override bool CheckTrigger() {
        return weapon1.CheckTrigger() || weapon2.CheckTrigger();
    }

    public override void Shoot() {
        weapon1.Shoot();
        weapon2.Shoot();
    }


}
