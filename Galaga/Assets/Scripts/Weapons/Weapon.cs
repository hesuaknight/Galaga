using UnityEngine;

public abstract class Weapon {

    public static ObjectPool<Bullet> poolObject = new ObjectPool<Bullet>(1, new BulletFactory());

    protected Transform _spawnPoint;
    protected KeyCode _fireKey;
    protected float _timer;
    protected float _fireCoolDown;

    public float fireCoolDown { get { return _fireCoolDown; } }

    public Weapon(KeyCode kcFire, Transform spawnPoint, float fireCoolDown) {
        _fireKey = kcFire;
        _spawnPoint = spawnPoint;
        _timer = 0;
        this._fireCoolDown = fireCoolDown;
    }

    public Weapon() { }

    public abstract void Shoot();
    public abstract bool CheckTrigger();
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
    }
}

