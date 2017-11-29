using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    private PlayerController _controller;
    public PlayerController controller { set { _controller = value; } get { return _controller; } }
    public LifeController lifeController;
    public Transform shootPoint;
    private Weapon _weapon;
    public Weapon weapon { get { return _weapon; } set { _weapon = value; } }

    public PlayerSubject _playerSubject;
    private CheckPoint _checkPoint;

    private void Awake() {
        lifeController = new LifeController();
        lifeController.currentLife = lifeController.maxLife;
        lifeController.OnDeadCallBack += LoadCheckPoint;
    }

    void Start() {
        //_controller = new KeyboardCtrl(this);
        //_weapon = new WeaponStandard(() => { return Input.GetKeyDown(_controller.fireKey); }, shootPoint, Constants.layerPlayer, 0.35f);
        //_weapon = new WeaponSpread3x(() => { return Input.GetKeyDown(controller.fireKey); }, shootPoint, Constants.layerPlayer, 0.5f);
        //_weapon = new WeaponSemiAuto(() => { return Input.GetKey(controller.fireKey); }, shootPoint, Constants.layerPlayer, 0.25f);

        _weapon = new WeaponComplex(new WeaponSemiAuto(() => { return Input.GetKey(controller.fireKey); }, shootPoint, Constants.layerPlayer, 0.25f),
                                              new WeaponSpread3x(() => { return Input.GetKey(controller.fireKey); }, shootPoint, Constants.layerPlayer, 0.5f));


        _checkPoint = new CheckPoint(transform.position, _weapon);
        _playerSubject = new PlayerSubject();
    }

    // Update is called once per frame
    void Update() {
        _controller.Update();
        _weapon.Update();
    }

    public void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void SetCheckPoint() {
        _checkPoint.SetCheckPoint(transform.position, _weapon);
    }

    public void LoadCheckPoint() {
        _playerSubject.NotiffyAll();
        lifeController.RestoreLife();
        _checkPoint.LoadCheckPoint(this);
    }
}










//Cuando?