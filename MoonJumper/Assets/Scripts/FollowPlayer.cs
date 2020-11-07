using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerPos;
    private float playerStartPos;

    void Start() {
        playerStartPos = playerPos.position.x;
    }

    void Update() {
        transform.position = new Vector3(playerPos.position.x - playerStartPos, transform.position.y, transform.position.z);
    }

}
