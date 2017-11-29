using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {

    public GameObject pausePanel;
    public Text invulnerabilityText;
    public bool invulnerability;

    // Use this for initialization
    void Start () {
        invulnerability = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            PauseGame();
        else if (Input.GetKeyDown(KeyCode.W))
            SetInvulnerability();
	}

    public void PauseGame() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void SetInvulnerability() {
        Debug.Log("Invulnerability!");
        invulnerability = !invulnerability;
        invulnerabilityText.enabled = invulnerability ? true : false;
    }
}
