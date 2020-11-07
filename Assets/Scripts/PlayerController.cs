using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    private CapsuleCollider2D collider;
    private Animator anim;

    private float speed = 5f;
    private float jumpForce = 14f;
    private float jumpTimeCounter;
    private float jumpTime = 0.2f;

    private bool isGrounded = true;
    private bool isJumping = false;
    private bool jumpingGround = false;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    void Update() {
        HandleJump();
        HandleScore();
    }

    void HandleJump() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded && !FindObjectOfType<Hole>().died) {
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
        Vector3 playerDownPos = new Vector3(transform.position.x, -1 * 5f, 0f);
        Debug.DrawLine(transform.position, playerDownPos, Color.red);
        
        IsHoleSkipped(transform.position, playerDownPos);
    }

    void IsHoleSkipped(Vector2 start, Vector2 end) {
        RaycastHit2D results = Physics2D.Raycast(start, end);

        if (results) {
            if (results.collider.tag == "Hole" && !jumpingGround) {
                jumpingGround = true;
                Invoke("AddScore", 0.4f);
            }
            if (results.collider.tag == "Ground") {
                jumpingGround = false;
            }
        }
    }

    void AddScore() {
        Debug.Log("Yay!");
    }

    // void IsHoleSkipped(Collider2D moveCollider, Vector2 direction, float distance) {
    //     RaycastHit2D[] hits = new RaycastHit2D[10];
    //     ContactFilter2D filter = new ContactFilter2D() {};
        
    //     int numHits = moveCollider.Cast(direction, filter, hits, distance);
        
    //     for (int i = 0; i < numHits; i++) {
    //         if (hits[i].collider.gameObject.tag == "Hole") {
    //             Debug.Log("Buraco abaixo");
    //         }
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            anim.enabled = true;
            isGrounded = true;
        }
    }

}
