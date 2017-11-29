using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour ,IPowerUp{
    public void Displacement()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }
    private void Update()
    {
        Displacement();
    }

    public void OnTakePowerUP(Player player)
    {
        player.GetComponentInChildren<ShieldRoot>().ActiveNewShield();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            OnTakePowerUP(c.gameObject.GetComponent<Player>());
        }
    }
}
