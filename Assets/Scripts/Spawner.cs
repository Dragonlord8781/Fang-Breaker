using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int enemiesToSpawn;

    private GameObject spawnPoint;
    GameObject[] spawnPoints;

    private GameObject enemy;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    GameObject[] enemiesInScene;

    private int randomNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesToSpawn = 5;

        FindRanNum();

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoint = spawnPoints[randomNum];

        Debug.Log("Found " + spawnPoint);

        Spawn();
    }

    private void FindRanNum()
    {
        randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);
    }

    private void ChooseEnemy()
    {
        List<GameObject> enemies = new List<GameObject>
        {
            enemy1,
            enemy2,
            enemy3,
            enemy4
        };

        enemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];
    }

    private void Spawn()
    {
        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            FindRanNum();

            spawnPoint = spawnPoints[randomNum];
            Debug.Log("Found " + spawnPoint);

            ChooseEnemy();

            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
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
        //Debug.Log("Found " + enemiesInScene.Length + " enemies left.");
        return enemiesInScene.Length;
    }
}
