using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSemiAuto : Weapon {

    public WeaponSemiAuto(KeyCode kcFire, Transform spawnPoint, float fireCoolDown) : base(kcFire, spawnPoint, fireCoolDown) { }

    public override bool CheckTrigger() {
        return Input.GetKey(_fireKey);
    }

    public override void Shoot() {
        PositionBullet(poolObject.Acquiere());
    }
}
