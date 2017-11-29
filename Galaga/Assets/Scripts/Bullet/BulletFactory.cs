using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IPoolFactory<Bullet> {

    private GameObject bulletPrefab;

    public BulletFactory() {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }
    
    public Bullet Create() {
        return Object.Instantiate(bulletPrefab).GetComponent<Bullet>();
    }

}
