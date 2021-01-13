using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    private SpriteRenderer playerSpriteRenderer;
    private CapsuleCollider2D playerCollider;

    private GameController gameController;

    void Start() {
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>();

        gameController = FindObjectOfType<GameController>();
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            gameController.playerDied = true;
            other.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    void Update() {
        if (gameController.playerDied) {
            Color color = playerSpriteRenderer.color;
            color.a = Mathf.Lerp(color.a, 0f, Time.deltaTime * 2); 

            playerSpriteRenderer.color = color;

            Invoke("ShowGameOverCanvas", 0.5f);
        }
    }

    void ShowGameOverCanvas() {
        gameController.ShowGameOverCanvas();
    }

}
