using System;
using UnityEngine;

public abstract class Weapon {

    public static ObjectPool<Bullet> poolObject = new ObjectPool<Bullet>(1, new BulletFactory());

    protected Transform _spawnPoint;
    protected Func<bool> _trigger;
    protected float _timer;
    protected float _fireCoolDown;

    private int _shootLayer;

    public float fireCoolDown { get { return _fireCoolDown; } }

    public Weapon(Func<bool> trigger, Transform spawnPoint, int shootLayer, float fireCoolDown) {
        _trigger = trigger;
        _spawnPoint = spawnPoint;
        _shootLayer = shootLayer;
        _timer = 0;
        this._fireCoolDown = fireCoolDown;
    }

    public Weapon() { }

    public abstract void Shoot();
    public virtual bool CheckTrigger() { return _trigger(); }
    public bool canShoot() { return _timer >= _fireCoolDown; }

    public virtual void Update() {//Funcion a poner en el update del que poseea weapon (Enemy / Player)
        _timer += Time.deltaTime;
        if(CheckTrigger() && canShoot()) {
            Shoot();
            _timer = 0;
        }
    }

    protected void PositionBullet(Bullet bullet) {
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
        bullet.gameObject.layer = _shootLayer;
    }
}

