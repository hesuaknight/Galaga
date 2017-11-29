using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStandard : Weapon {

    public WeaponStandard(KeyCode kcFire, Transform spawnPoint, float fireCoolDown) : base(kcFire, spawnPoint, fireCoolDown) { }

    public override bool CheckTrigger() {
        return Input.GetKeyDown(_fireKey);
    }

    public override void Shoot() {
        PositionBullet(poolObject.Acquiere());
    }
}
