using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon {
    public static ObjectPool<Bullet> poolObject = new ObjectPool<Bullet>(1, new BulletFactory());

    private Transform _shootPosition;
    private int _shootLayer;

    public EnemyWeapon(Transform shootPosition, int shootLayer) {
        _shootPosition = shootPosition;
        _shootLayer = shootLayer;
    }


    public void Shoot() {
        Bullet bullet = poolObject.Acquiere();
        bullet.transform.position = _shootPosition.position;
        bullet.transform.forward = _shootPosition.forward;
        //bullet.transform.forward = Vector3.down;
        bullet.gameObject.layer = _shootLayer;
    }
}
