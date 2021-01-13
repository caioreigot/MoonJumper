using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rig;
    private Animator anim;

    private float speed = 5f;
    private float jumpForce = 14f;
    private float jumpTimeCounter;
    private float jumpTime = 0.2f;

    private bool isGrounded = true;
    private bool isJumping = false;

    private GameController gameController;
    private Score score;

    private float maxScoreTimer = 0.9f;
    private float currentScoreTimer;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        gameController = FindObjectOfType<GameController>();
        score = FindObjectOfType<Score>();

        currentScoreTimer = maxScoreTimer;
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    void Update() {
        HandleJump();
        HandleScore();
    }

    void HandleJump() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded && !gameController.playerDied) {
            jumpTimeCounter = jumpTime;
            rig.velocity = new Vector2(rig.velocity.x, 1 * jumpForce);

            anim.enabled = false;

            isJumping = true;
            isGrounded = false;
        }

        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && isJumping) {
            if (jumpTimeCounter > 0) {
                rig.velocity = new Vector2(rig.velocity.x, 1 * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            } 
        } else {
            isJumping = false;
        }
    }

    void HandleScore() {
        if (currentScoreTimer <= 0) {
            AddScore();
            currentScoreTimer = maxScoreTimer;
        } else 
            currentScoreTimer -= Time.deltaTime;
    }

    void AddScore() {
        score.IncreaseScore();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            anim.enabled = true;
            isGrounded = true;
        }
    }

}
