using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private int enemiesToSpawn;

    private GameObject spawnPoints;

    public GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesToSpawn = 5;

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
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
        
    }
}
