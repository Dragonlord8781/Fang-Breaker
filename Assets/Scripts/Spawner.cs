using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;
using UnityEngine.UIElements;


public class Spawner : MonoBehaviour
{
    private int enemiesToSpawn;

    private GameObject spawnPoint;
    GameObject[] spawnPoints;

    private GameObject enemy;

    public GameObject enemy1;

    GameObject[] enemiesInScene;

    public int currentWaveNum;
    public int enemiesLeft;
    public int totalEnemies;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI countText;

    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    public Transform spawnerTransform;

    private int pickUpsToSpawn;

    private GameObject pickUpPoint;
    GameObject[] pickUpPoints;

    private GameObject pickUp;
    public GameObject pickUp1;

    private Vector3 ranPickUpPointRange;
    private Vector3 ranSpawnPointRange;

    private Transform pickUpTransform;
    private float xPosition;
    private float yPosition;
    private float zPosition;
    private float ranX;
    private float ranY;
    private float ranZ;

    public float randomSpread;

    private Vector3 pickUpLocation;

    public int allEnemies;
    public bool newGame = true;

    public GameObject killMarker;
    public float delayTime;

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
        
            enemiesToSpawn = PlayerData.Instance.enemyCount;
            totalEnemies = PlayerData.Instance.enemyTotal;
            enemiesLeft = totalEnemies;

            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

            Debug.Log("Found " + spawnPoint);

            currentWaveNum = PlayerData.Instance.waveCount;
            waveText.text = "Wave: " + currentWaveNum.ToString();

            countText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Foes Left";

            pickUpsToSpawn = 5;
            pickUpPoints = GameObject.FindGameObjectsWithTag("PickupPoint");
            pickUpPoint = pickUpPoints[UnityEngine.Random.Range(0, pickUpPoints.Length)];

            Spawn();
        
    }

    private void ChooseEnemy()
    {
        List<GameObject> enemies = new List<GameObject>
        {
            enemy1
        };

        enemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];
    }

    private void ChoosePickup()
    {
        List<GameObject> pickUps = new List<GameObject>
        {
            pickUp1
        };

        pickUp = pickUps[UnityEngine.Random.Range(0, pickUps.Count)];
    }

    private void Spawn()
    {
        for (int i = 1; i <= enemiesToSpawn; i++)
        {

            spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            Debug.Log("Found " + spawnPoint);

            ChooseEnemy();
            RandomSpawnerRange();

            Instantiate(enemy, ranSpawnPointRange, Quaternion.identity);
        }

        for (int i = 1; i <= pickUpsToSpawn; i++)
        {
            pickUpPoint = pickUpPoints[UnityEngine.Random.Range(0,pickUpPoints.Length)];

            ChoosePickup();
            RandomPickupRange();

            Instantiate(pickUp, ranPickUpPointRange, Quaternion.identity);
        }
    }

    private void RandomPickupRange()
    {
        pickUpTransform = pickUpPoint.transform;
        xPosition = pickUpTransform.position.x;
        yPosition = pickUpTransform.position.y;
        zPosition = pickUpTransform.position.z;

        ranX = UnityEngine.Random.Range(xPosition - randomSpread, xPosition + randomSpread);
        ranY = UnityEngine.Random.Range(yPosition - randomSpread, yPosition + randomSpread);
        ranZ = UnityEngine.Random.Range(zPosition - randomSpread, zPosition + randomSpread);

        ranPickUpPointRange = new Vector3(ranX, yPosition, ranY);
    }

    // Update is called once per frame
    void Update()
    {
        CountObjectsWithTag();
        countText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Foes Left";


        if (enemiesInScene.Length == 0)
        {
            PlayerData.Instance.enemyTotal += 5;

            currentWaveNum++;
            PlayerData.Instance.waveCount = currentWaveNum;
            totalEnemies = PlayerData.Instance.enemyTotal;
            enemiesToSpawn = totalEnemies;
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
        if(enemiesInScene.Length < enemiesLeft)
        {
            killMarker.SetActive(true);
            StartCoroutine(DelayedActionCoroutine());
        }
        //Debug.Log("Found " + enemiesInScene.Length + " enemies left.");
        enemiesLeft = enemiesInScene.Length;
        PlayerData.Instance.enemyCount = enemiesLeft;
        return enemiesInScene.Length;
    }

    private IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        killMarker.SetActive(false);
    }

    private void RandomSpawnerRange()
    {
        spawnerTransform = spawnPoint.transform;
        xPosition = spawnerTransform.position.x;
        yPosition = spawnerTransform.position.y;
        zPosition = spawnerTransform.position.z;

        ranX = UnityEngine.Random.Range(xPosition - randomSpread, xPosition + randomSpread);
        ranY = UnityEngine.Random.Range(yPosition - randomSpread, yPosition + randomSpread);
        ranZ = UnityEngine.Random.Range(zPosition - randomSpread, zPosition + randomSpread);

        ranSpawnPointRange = new Vector3(ranX, yPosition, ranY);
    }
}
