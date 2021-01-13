using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour {

    [Range(0, 6)]
    public int minHoleSpawnDistance;

    [Range(6, 14)]
    public int maxHoleSpawnDistance;

    private float groundLength, groundDeslocationPos;
    private float holeDeslocationPos = 34f;
    
    [Header("Ground Prefab")]
    public GameObject groundPrefab;

    // Ground
    private float maxGroundSpawnTimer = 8f;
    private float spawnGroundTimer;
    
    private float maxGroundRemoveTimer = 14f;
    private float removeGroundTimer;

    // Hole
    private float maxHoleSpawnTimer = 1.2f;
    private float spawnHoleTimer;

    private float maxHoleRemoveTimer = 12f;
    private float removeHoleTimer;

    [Header("Holes Prefabs")]
    public GameObject holeS;
    public GameObject holeM;
    public GameObject holeG;

    private const float holeSpawnOffsetY = -3.579618f;

    void Start() {
        spawnGroundTimer = maxGroundSpawnTimer;
        removeGroundTimer = maxGroundRemoveTimer;

        spawnHoleTimer = maxHoleSpawnTimer;
        removeHoleTimer = maxHoleRemoveTimer;

        // Multiplying by 4 because there are 4 sprintes together forming one
        groundLength = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x * 4;
        groundDeslocationPos = groundLength;
    }

    void Update() {
        SpawnGrounds();
        SpawnHoles();
    }

    void SpawnGrounds() {
        if (spawnGroundTimer <= 0) {
            // Instantiating new grounds
            Instantiate(groundPrefab, new Vector3(groundDeslocationPos, groundPrefab.transform.position.y, 0f), Quaternion.identity);
            
            // Shifting the position of the next spawn in front of the ground already spawned
            groundDeslocationPos += groundLength;
            spawnGroundTimer = maxGroundSpawnTimer + 2.5f;
        }
        else 
            spawnGroundTimer -= Time.deltaTime;
        
        // Timer to destroy old grounds
        if (removeGroundTimer <= 0) {
            Destroy(GameObject.FindGameObjectWithTag("Ground"));
            removeGroundTimer = maxGroundRemoveTimer;
        } else 
            removeGroundTimer -= Time.deltaTime;
    }

    void SpawnHoles() {
        if (spawnHoleTimer <= 0) {
            // Instantiating new holes
            GameObject holePrefab = null;
            int randomInt = Random.Range(0, 3);

            switch (randomInt) 
            {
                case 0:
                    holePrefab = holeS;
                    break;

                case 1:
                    holePrefab = holeM;
                    break;

                case 2:
                    holePrefab = holeG;
                    break;
                
                default:
                    break;
            }

            Instantiate(holePrefab, new Vector3(holeDeslocationPos, holeSpawnOffsetY, 0f), Quaternion.identity);
            
            // Shifting the position of the next spawn in front of the Hole already spawned
            float randomDistance = holePrefab.GetComponent<SpriteRenderer>().bounds.size.x + Random.Range(minHoleSpawnDistance, maxHoleSpawnDistance);
            holeDeslocationPos += randomDistance;

            spawnHoleTimer = maxHoleSpawnTimer;
        }
        else 
            spawnHoleTimer -= Time.deltaTime;
        
        // Timer to destroy old Holes
        if (removeHoleTimer <= 0) {
            Destroy(GameObject.FindGameObjectWithTag("Hole"));
            removeHoleTimer = maxHoleRemoveTimer;
        } else 
            removeHoleTimer -= Time.deltaTime;
    }

}
