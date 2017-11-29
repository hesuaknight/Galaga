using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject {

    public float speed;

    private void Awake() {
        gameObject.SetActive(false);
    }

	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision) {
        //Codigo para restar vida a lo que le pegue.
        Weapon.poolObject.Release(this);
    }

    public void OnAdquiere() {
        gameObject.SetActive(true);
    }

    public void OnRelease() {
        gameObject.SetActive(false);
    }
}
