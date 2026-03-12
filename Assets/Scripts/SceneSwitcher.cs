using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Spawner enemyController;

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
            DontDestroyOnLoad(gameObject);
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
        SceneManager.LoadScene("Dead Ruins");
        enemyController.newGame = true;
    }

    public void QuitGame()
    {
        PlayerData.Instance.QuitAddUp();
        SceneManager.LoadScene("Main Menu");
    }

    public void StartOldGame()
    {
        SceneManager.LoadScene("Dead Ruins");
        enemyController.newGame = false;
    }
}
