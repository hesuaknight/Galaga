using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpread3x : Weapon {

    public WeaponSpread3x(Func<bool> trigger, Transform spawnPoint, int shooterLayer, float fireCoolDown) : base(trigger, spawnPoint,shooterLayer, fireCoolDown) { }


    public override void Shoot() {
        //Codigo de disparo
        Bullet bullet = poolObject.Acquiere();
        Bullet bullet2 = poolObject.Acquiere();

        PositionBullet(bullet);
        PositionBullet(bullet2);
        PositionBullet(poolObject.Acquiere());

        bullet.transform.Rotate(bullet.transform.forward, 30);
        bullet2.transform.Rotate(bullet2.transform.forward, -30);
    }
}
