using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    PlayerController controller;
    public LifeController lifeController;
    public Transform shootPoint;
    private Weapon _weapon;
    public Weapon weapon { get { return _weapon; } set { _weapon = value; } }

    private CheckPoint _checkPoint;

    private void Awake() {
        lifeController = new LifeController();
        lifeController.currentLife = lifeController.maxLife;
        lifeController.OnDeadCallBack += LoadCheckPoint;
    }

    void Start() {
        controller = new KeyboardCtrl(this);
        _weapon = new WeaponStandard(controller.fireKey, this.transform, 0.35f);
        _checkPoint = new CheckPoint(transform.position, _weapon);
    }

    // Update is called once per frame
    void Update() {
        controller.Update();
        _weapon.Update();
    }

    public void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void SetCheckPoint() {
        _checkPoint.SetCheckPoint(transform.position, _weapon);
    }

    public void LoadCheckPoint() {
        _checkPoint.LoadCheckPoint(this);
    }
}
