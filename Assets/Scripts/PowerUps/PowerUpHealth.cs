using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour, IPowerUp {

    public int lifeRestore = 1;

    public void OnTakePowerUP(Player player)
    {
        int b = player.lifeController.currentLife;
        player.lifeController.maxLife += lifeRestore;
        Debug.Log("POWERUP - Life regenerato From :" + b + " to : " + player.lifeController.currentLife);
        RemovePowerUp();
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            OnTakePowerUP(c.GetComponent<Player>());
        }
    }

    private void RemovePowerUp()
    {
        Destroy(this.gameObject);
    }

}
