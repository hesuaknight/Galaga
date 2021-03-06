﻿using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject level1Enemy;
    public GameObject winPanel;
    private GameObject[]players;
    public GameObject[] powerUps;
    public static GameManager instance;

    public GameStatus gameStatus;
    public GameCtrl gameCtrl;

    private void Awake()
    {
        instance = this;
        players = GameObject.FindGameObjectsWithTag("Player");
        gameStatus = new GameStatus();
    }

    private void Start()
    {
        GridFormationRoot.instance.CreateGrid(level1Enemy);

    }

    private void Update()
    {
        CheckLifePlayersCanvas();
    }

    public void CheckLifePlayersCanvas()
    {
        if (players.Length == 1)
        {
            Player p1 = players[0].GetComponent<Player>();
            GameObject.Find("LifeP1").GetComponent<Text>().text = "LIFE : " + p1.lifeController.currentLife + " / " + p1.lifeController.maxLife;
            GameObject.Find("LifeP2").GetComponent<Text>().text = "";

        }
        else if (players.Length == 2)
        {
            Player p1 = players[0].GetComponent<Player>();
            Player p2 = players[1].GetComponent<Player>();
            GameObject.Find("LifeP1").GetComponent<Text>().text = "P1 LIFE : " + p1.lifeController.currentLife + " / " + p1.lifeController.maxLife;
            GameObject.Find("LifeP2").GetComponent<Text>().text = "P2 LIFE : " + p2.lifeController.currentLife + " / " + p2.lifeController.maxLife;
        }
    }

    public void EnemyAlive() {
        gameStatus.enemyAliveCount++;
    }

    public void EnemyDie() {
        //Debug.Log(gameStatus.enemyAliveCount);

        if (gameStatus.EnemyDie() == GameStatus.CurrentGameStatus.AllEnemyDead) {
            if (winPanel.gameObject == null) return;
            winPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
