using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDownHell : MonoBehaviour, IPowerUp {
    public int lifeRemove = 1;

    public void OnTakePowerUP(Player player)
    {
        int b = player.lifeController.currentLife;
        player.lifeController.maxLife -= lifeRemove;
        Debug.Log("POWERUP - Life removed From :" + b + " to : " + player.lifeController.currentLife);
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
