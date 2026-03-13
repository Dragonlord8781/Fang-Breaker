using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private static SceneSwitcher _instance;
    public static SceneSwitcher Instance { get { return _instance; } }

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PlayerData.Instance.StartNewGame();
        SceneManager.LoadScene("Dead Ruins");
    }

    public void QuitGame()
    {
        PlayerData.Instance.QuitAddUp();
        SceneManager.LoadScene("Main Menu");
    }

    public void StartOldGame()
    {
        PlayerData.Instance.RestartOldGame();
        SceneManager.LoadScene("Dead Ruins");
    }
}
