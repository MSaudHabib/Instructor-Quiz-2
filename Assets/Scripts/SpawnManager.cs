using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs = new GameObject[4];
    public float startDelay = 1;
    public float repeatDelay = 5;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        // Spawning enemies repeateadly on defined spawn points
        if (!playerController.gameOver)
        {
            InvokeRepeating("SpawnEnemies", startDelay, repeatDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        // Spawning enemy prefabs
        Instantiate(enemyPrefabs[0], enemyPrefabs[0].transform.position, enemyPrefabs[0].transform.rotation);
        Instantiate(enemyPrefabs[1], enemyPrefabs[1].transform.position, enemyPrefabs[0].transform.rotation);
        Instantiate(enemyPrefabs[2], enemyPrefabs[2].transform.position, enemyPrefabs[0].transform.rotation);
        Instantiate(enemyPrefabs[3], enemyPrefabs[3].transform.position, enemyPrefabs[0].transform.rotation);
    }
}
