using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool playerDied = false;
    public GameObject gameOverCanvas;

    public void ShowGameOverCanvas() {
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
