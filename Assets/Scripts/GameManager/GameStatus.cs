using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    public static int enemyAliveCount;
    public CurrentGameStatus currentStatus; public enum CurrentGameStatus { PlayerDead, NotShootOnScreen, AllEnemyDead}
    public static int shootOnScreenCount;
    void checkStatus()
    {
        if (Enemy.player.GetComponent<Player>().lifeController.currentLife <= 0)
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

