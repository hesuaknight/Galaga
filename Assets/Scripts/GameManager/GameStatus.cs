using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    public static int enemyAliveCount;
    public CurrentGameStatus currentStatus; public enum CurrentGameStatus { PlayerDead, NotShootOnScreen, AllEnemyDead}
    public static int shootOnScreenCount;

    public GameObject[] Players;

    private void Awake()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
    }
    void checkStatus()
    {
        if (Players.Length == 2 && Players[0].GetComponent<Player>().lifeController.currentLife <= 0 && Players[1].GetComponent<Player>().lifeController.currentLife <= 0)
        {
            currentStatus = CurrentGameStatus.PlayerDead;
        }
        else if (enemyAliveCount == 0)
        {
            currentStatus = CurrentGameStatus.AllEnemyDead;
        }        
        else if (shootOnScreenCount == 0)
        {
            currentStatus = CurrentGameStatus.NotShootOnScreen;
        }
    }
}

