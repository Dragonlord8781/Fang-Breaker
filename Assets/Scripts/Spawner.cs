using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private int currentWaveNum;
    private int enemiesLeft;
    private int totalEnemies;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI countText;

    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesToSpawn = 5;
        totalEnemies = enemiesToSpawn;
        enemiesLeft = totalEnemies;

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        Debug.Log("Found " + spawnPoint);

        currentWaveNum = 1;
        waveText.text = "Wave: " + currentWaveNum.ToString();

        countText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Foes Left";

        Spawn();
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
        for (int i = 1; i <= enemiesToSpawn; i++)
        {

            spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            Debug.Log("Found " + spawnPoint);

            ChooseEnemy();

            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountObjectsWithTag();
        countText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Foes Left";

        if (enemiesInScene.Length == 0)
        {
            enemiesToSpawn += 5;

            currentWaveNum++;
            totalEnemies = enemiesToSpawn;
            enemiesLeft = totalEnemies;

            Spawn();

            waveText.text = "Wave: " + currentWaveNum.ToString();
            countText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Foes Left";
        }
    }

    public int CountObjectsWithTag()
    {
        // Find all active GameObjects with the specified tag and return the array's length
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log("Found " + enemiesInScene.Length + " enemies left.");
        enemiesLeft = enemiesInScene.Length;
        return enemiesInScene.Length;
    }
}
