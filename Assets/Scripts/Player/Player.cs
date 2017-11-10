using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;

    PlayerController controller;
    Weapon weapon;

	void Start () {
        controller = new KeyboardCtrl(this);
        weapon = new WeaponStandard(controller.fireKey, this.transform, 0.35f);
	}
	
	// Update is called once per frame
	void Update () {
        controller.Update();
        weapon.Update();
	}

    public void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
    }
}
