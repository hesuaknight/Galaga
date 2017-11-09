using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Weapon weapon;
    public Transform spawnPoint;
    // Use this for initialization
    void Start() {
        weapon = new WeaponStandard(KeyCode.Space, spawnPoint, 1);
    }

    // Update is called once per frame
    void Update() {
        weapon.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            weapon = new WeaponStandard(KeyCode.Space, spawnPoint, 1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            weapon = new WeaponSemiAuto(KeyCode.Space, spawnPoint, 0.25f);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            weapon = new WeaponSpread3x(KeyCode.Space, spawnPoint, 0.5f);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            weapon = new WeaponComplex(new WeaponSemiAuto(KeyCode.Space, spawnPoint, 0.3f), new WeaponSpread3x(KeyCode.Space, spawnPoint, 0.8f));
    }
}
