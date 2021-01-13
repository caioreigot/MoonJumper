using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject score;
    private Text scoreText;

    void Start() {
        scoreText = score.GetComponent<Text>();

        scoreText.text = FindObjectOfType<Score>()
                         .GetScore()
                         .ToString();
    }

}
