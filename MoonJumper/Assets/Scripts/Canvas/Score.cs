using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

    void Start() {
        scoreText = GetComponent<Text>();
    }

    public void IncreaseScore() {
        score++;

        scoreText.text = score.ToString();
    }

    public int GetScore() {
        return score;
    }

}
