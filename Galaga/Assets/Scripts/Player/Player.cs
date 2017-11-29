using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    PlayerController controller;
    public LifeController lifeController;
    public Transform shootPoint;
    private Weapon _weapon;

    public Weapon weapon { get { return _weapon; } set { _weapon = value; } }
    private void Awake()
    {
        lifeController = new LifeController();
        lifeController.currentLife = lifeController.maxLife;
    }
    void Start () {

        controller = new KeyboardCtrl(this);
        _weapon = new WeaponStandard(controller.fireKey, this.transform, 0.35f);
	}
	
	// Update is called once per frame
	void Update () {
        controller.Update();
        _weapon.Update();
	}

    public void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
    }
}
