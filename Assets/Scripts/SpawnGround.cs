using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    private float length, deslocationPos;
    public GameObject cam;

    public GameObject groundPrefab;
    public GameObject firstGround;

    private float maxSpawnTimer = 8f;
    private float spawnTimer;
    
    private float maxRemoveTimer = 14f;
    private float removeTimer;

    void Start() {
        spawnTimer = maxSpawnTimer;
        removeTimer = maxRemoveTimer;

        // Multiplying by 4 because there are 4 sprintes together forming one
        length = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x * 4;
        deslocationPos = length;
    }

    void Update() {
        if (spawnTimer <= 0) {
            Instantiate(groundPrefab, new Vector3(deslocationPos, groundPrefab.transform.position.y, 0f), Quaternion.identity);
            
            // Shifting the position of the next spawn in front of the ground already spawned
            deslocationPos += length;
            spawnTimer = maxSpawnTimer + 2.5f;
        }
        else spawnTimer -= Time.deltaTime;
        
        if (removeTimer <= 0) {
            Destroy(GameObject.FindGameObjectWithTag("Ground"));
            removeTimer = maxRemoveTimer;
        } else removeTimer -= Time.deltaTime;
    }

}
