using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool playerDied = false;
    public GameObject gameOverCanvas;

    [Header("Dificulty")]
    public float amountToIncrease = 0.01f;
    public float timerToIncreaseDifficulty = 1f;
    private float timer;

    void Start() {
        timer = timerToIncreaseDifficulty;
    }

    void Update() {
        IncreaseDifficulty();
    }

    public void ShowGameOverCanvas() {
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    void IncreaseDifficulty() {
        if (timer <= 0 && !playerDied) {
            Time.timeScale += amountToIncrease;
            timer = timerToIncreaseDifficulty;
        } else {
            if (timer > 0)
                timer -= Time.deltaTime;
            if (playerDied)
                Time.timeScale = 1f;
        }
            
    }

}
