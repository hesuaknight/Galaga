using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private Weapon weapon;
    private IPowerUp[] powerUps;

    public void LoadCheckPoint(Player player) {
        weapon = player.weapon;
        powerUps = player.GetComponents<IPowerUp>();
    }
}
