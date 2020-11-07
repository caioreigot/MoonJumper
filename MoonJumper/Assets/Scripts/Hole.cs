using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private SpriteRenderer playerSpriteRenderer;
    private CapsuleCollider2D playerCollider;

    public bool died = false;

    void Start() {
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            died = true;
        }
    }

    void Update() {
        if (died) {
            Color color = playerSpriteRenderer.color;
            color.a = Mathf.Lerp(color.a, 0f, Time.deltaTime * 6); 

            playerSpriteRenderer.color = color;

            Invoke("Freeze", 0.5f);
        }
    }

    void Freeze() {
        Time.timeScale = 0f;
    }


}
