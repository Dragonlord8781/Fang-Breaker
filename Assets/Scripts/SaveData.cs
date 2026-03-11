using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public PlayerManager playerData;
    public Spawner enemyData;

    private int highScore;
    private int highestWave;
    private int mostEnemiesKilled;

    private int totalScore;
    private int totalWaves;
    private int totalEnemiesKilled;

    private int lastScore;
    private int lastWave;
    private int lastEnemies;
    private int lastTotalEnemies;

    public TextMeshProUGUI highScoreCounter;
    public TextMeshProUGUI highestWaveCounter;
    public TextMeshProUGUI MostEnemiesKilledCounter;

    public TextMeshProUGUI totalScoreCounter;
    public TextMeshProUGUI totalWaveCounter;
    public TextMeshProUGUI totalEnemiesKilledCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreCounter.text = "HighScore: " + highScore;
        highestWaveCounter.text = "Best Wave: " + highestWave;
        MostEnemiesKilledCounter.text = "Highest Kill Count: " + mostEnemiesKilled;

        totalScoreCounter.text = "Lifetime Score: " + totalScore;
        totalWaveCounter.text = "Total Waves Fought: " + totalWaves;
        totalEnemiesKilledCounter.text = "Total Enemies Slain: " + totalEnemiesKilled;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeathAddUp()
    {
        if (highScore < playerData.currentPoints)
        {
            highScore = playerData.currentPoints;
        }
        if (highestWave < enemyData.currentWaveNum)
        {
            highestWave = enemyData.currentWaveNum;
        }
        if (mostEnemiesKilled < enemyData.totalEnemies - enemyData.enemiesLeft)
        { 
            mostEnemiesKilled = enemyData.totalEnemies - enemyData.enemiesLeft;
        }

        totalScore += playerData.currentPoints - lastScore;
        totalWaves += enemyData.currentWaveNum - (lastTotalEnemies - lastEnemies);
        totalEnemiesKilled += enemyData.totalEnemies - enemyData.enemiesLeft;
    }

    public void QuitAddUp()
    {

    }
}
