using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreCounter;
    public TextMeshProUGUI highestWaveCounter;
    public TextMeshProUGUI MostEnemiesKilledCounter;

    public TextMeshProUGUI totalScoreCounter;
    public TextMeshProUGUI totalWaveCounter;
    public TextMeshProUGUI totalEnemiesKilledCounter;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreCounter.text = "HighScore: " + PlayerData.Instance.highScore;
        highestWaveCounter.text = "Best Wave: " + PlayerData.Instance.highestWave;
        MostEnemiesKilledCounter.text = "Highest Kill Count: " + PlayerData.Instance.mostEnemiesKilled;

        totalScoreCounter.text = "Lifetime Score: " + PlayerData.Instance.totalScore;
        totalWaveCounter.text = "Total Waves Fought: " + PlayerData.Instance.totalWaves;
        totalEnemiesKilledCounter.text = "Total Enemies Slain: " + PlayerData.Instance.totalEnemiesKilled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
