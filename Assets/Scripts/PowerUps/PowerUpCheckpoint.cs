using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCheckpoint : MonoBehaviour, IPowerUp {

    public void OnTakePowerUP(Player player)
    {
        player.SetCheckPoint();
        Destroy(gameObject);
    }
    public void Displacement()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }

    private void Update() {
        Displacement();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            OnTakePowerUP(other.GetComponent<Player>());
        }
    }
}
