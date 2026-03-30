using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int points;
    public int killCount;
    public int enemyTotal;
    public int enemyCount;
    public int waveCount;

    public int highScore;
    public int highestWave;
    public int mostEnemiesKilled;

    public int totalScore;
    public int totalWaves;
    public int totalEnemiesKilled;

    public int lastScore;
    public int lastWave;
    public int lastEnemies;
    public int lastTotalEnemies;
    public int lastKillCount;

    public bool isOldGame;
    public float playerHealth;
    public int rifleAmmo;
    public int revolverAmmo;
    public int shotgunAmmo;
    public int flamerAmmo;



    private static PlayerData _instance;
    public static PlayerData Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadPlayer();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeathAddUp()
    {
        ClearSave();
        isOldGame = false;
        if (highScore < points)
        {
            highScore = points;
        }
        if (highestWave < waveCount - 1)
        {
            highestWave = waveCount - 1;
        }
        if (mostEnemiesKilled < killCount)
        { 
            mostEnemiesKilled = killCount;
        }

        totalScore += points;
        totalWaves += waveCount - 1;
        totalEnemiesKilled += killCount;

        SavePlayer();
    }

    public void QuitAddUp()
    {
        lastScore = points;
        lastWave = waveCount;
        lastTotalEnemies = enemyTotal;
        lastEnemies = enemyCount;
        lastKillCount = killCount;
        isOldGame = true;

        SavePlayer();
    }

    public void StartNewGame()
    {
        ClearSave();
        points = 0;
        killCount = 0;
        enemyTotal = 5;
        enemyCount = 5;
        waveCount = 1;
    }

    public void RestartOldGame()
    {
        points = lastScore;
        killCount = lastKillCount;
        enemyTotal = lastTotalEnemies;
        enemyCount = lastEnemies;
        waveCount = lastWave;
    }

    public void ClearSave()
    {
        lastScore = 0;
        lastWave = 0;
        lastTotalEnemies = 0;
        lastEnemies = 0;
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    internal static void AddPoints()
    {
        throw new NotImplementedException();
    }

    public void AddKill(int killToAdd)
    {
        killCount++;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();

        points = data.points;
        killCount = data.killCount;
        enemyTotal = data.enemyTotal;
        enemyCount = data.enemyCount;
        waveCount = data.waveCount;
        highScore = data.highScore;
        highestWave = data.highestWave;
        mostEnemiesKilled = data.mostEnemiesKilled;
        totalScore = data.totalScore;
        totalWaves = data.totalWaves;
        totalEnemiesKilled = data.totalEnemiesKilled;
        lastScore = data.lastScore;
        lastWave = data.lastWave;
        lastEnemies = data.lastEnemies;
        lastTotalEnemies = data.lastTotalEnemies;
        lastKillCount = data.lastKillCount;
        isOldGame = data.isOldGame;
        playerHealth = data.playerHealth;
        rifleAmmo = data.rifleAmmo;
        revolverAmmo = data.revolverAmmo;
        shotgunAmmo = data.shotgunAmmo;
        flamerAmmo = data.flamerAmmo;
    }

    public void ClearData()
    {
        points = 0;
        killCount = 0;
        enemyTotal = 0;
        enemyCount = 0;
        waveCount = 0;
        highScore = 0;
        highestWave = 0;
        mostEnemiesKilled = 0;
        totalScore = 0;
        totalWaves = 0;
        totalEnemiesKilled = 0;
        lastScore = 0;
        lastWave = 0;
        lastEnemies = 0;
        lastTotalEnemies = 0;
        lastKillCount = 0;
        isOldGame = false;

        SavePlayer();
    }
}
