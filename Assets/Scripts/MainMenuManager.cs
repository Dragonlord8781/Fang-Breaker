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

    public GameObject settingMenu;
    public GameObject creditMenu;
    public GameObject mainMenu;
    public GameObject infoMenu;

    private GameObject startButton;
    private GameObject restartButton;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreCounter.text = "HighScore: " + PlayerData.Instance.highScore;
        highestWaveCounter.text = "Best Wave: " + PlayerData.Instance.highestWave;
        MostEnemiesKilledCounter.text = "Highest Kill Count: " + PlayerData.Instance.mostEnemiesKilled;

        totalScoreCounter.text = "Lifetime Score: " + PlayerData.Instance.totalScore;
        totalWaveCounter.text = "Total Waves Fought: " + PlayerData.Instance.totalWaves;
        totalEnemiesKilledCounter.text = "Total Enemies Slain: " + PlayerData.Instance.totalEnemiesKilled;

        startButton = GameObject.Find("Play");
        restartButton = GameObject.Find("ResumeButton");

        if(PlayerData.Instance.isOldGame)
        {
            restartButton.SetActive(true);
        }
        else
        {
            restartButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }    

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void CloseCredits()
    {
        creditMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenInfo()
    {
        mainMenu.SetActive(false);
        infoMenu.SetActive(true);
    }

    public void CloseInfo()
    {
        infoMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        PlayerData.Instance.SavePlayer();
        Application.Quit();
    }
}
