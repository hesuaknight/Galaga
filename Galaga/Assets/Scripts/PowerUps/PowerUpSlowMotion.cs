using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowMotion : MonoBehaviour, IPowerUp {
    public float slowPorcent;
    public float timeDurationEffect;
    public void OnTakePowerUP(Player player)
    {
        player.StartCoroutine(SlowMotion());
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
    IEnumerator SlowMotion()
    {
        Debug.Log("S");
        float corretTimeDelta = Time.timeScale;
        Time.timeScale = slowPorcent;
        yield return new WaitForSeconds(timeDurationEffect);
        Time.timeScale = corretTimeDelta;
        Debug.Log("A");
        RemovePowerUp();
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            OnTakePowerUP(c.gameObject.GetComponent<Player>());
        }
    }
    private void RemovePowerUp()
    {
        Destroy(this.gameObject);
    }

}
