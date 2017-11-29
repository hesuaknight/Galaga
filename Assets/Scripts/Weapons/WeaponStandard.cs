using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStandard : Weapon {

    public WeaponStandard(Func<bool> trigger, Transform spawnPoint,int shooterLayer, float fireCoolDown) : base(trigger, spawnPoint,shooterLayer, fireCoolDown) { }

    public override void Shoot() {
        PositionBullet(poolObject.Acquiere());
    }
}
