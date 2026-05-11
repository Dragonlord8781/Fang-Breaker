using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
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

    public SaveData (PlayerData playerData)
    {
        points = playerData.points;
        killCount = playerData.killCount;  
        enemyTotal = playerData.enemyTotal;
        enemyCount = playerData.enemyCount;
        waveCount = playerData.waveCount;
        highScore = playerData.highScore;
        highestWave = playerData.highestWave;
        mostEnemiesKilled = playerData.mostEnemiesKilled;
        totalScore = playerData.totalScore;
        totalWaves = playerData.totalWaves;
        totalEnemiesKilled = playerData.totalEnemiesKilled;
        lastScore = playerData.lastScore;
        lastWave = playerData.lastWave;
        lastEnemies = playerData.lastEnemies;
        lastTotalEnemies = playerData.lastTotalEnemies;
        lastKillCount = playerData.lastKillCount;
        isOldGame = playerData.isOldGame;
        playerHealth = playerData.playerHealth;
        rifleAmmo = playerData.rifleAmmo;
        revolverAmmo = playerData.revolverAmmo;
        shotgunAmmo = playerData.shotgunAmmo;
        flamerAmmo = playerData.flamerAmmo;
    }
    public SaveData()
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
        playerHealth = 0;
        rifleAmmo = 0;
        revolverAmmo = 0;
        shotgunAmmo = 0;
        flamerAmmo = 0;
    }
}
