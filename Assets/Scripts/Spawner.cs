using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private int enemiesToSpawn;

    private GameObject spawnPoints;

    public GameObject enemy;

    GameObject[] enemiesInScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesToSpawn = 5;

        spawnPoints = GameObject.FindGameObjectWithTag("SpawnPoint");

        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            Instantiate(enemy, spawnPoints.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountObjectsWithTag();

        if (enemiesInScene.Length == 0)
        {
            enemiesToSpawn += 5;

            Spawn();
        }
    }

    public int CountObjectsWithTag()
    {
        // Find all active GameObjects with the specified tag and return the array's length
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Found " + enemiesInScene.Length + " enemies left.");
        return enemiesInScene.Length;
    }
}
