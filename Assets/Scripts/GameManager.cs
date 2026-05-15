using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenuUi;
    public GameObject settingsMenu;
    public GameObject infoMenu;
    public GameObject mobileUI;
    public bool gameIsPaused = false; 
    public StarterAssetsInputs inputs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        if (mobileUI != null)
        {
            mobileUI.SetActive(true);
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        if (mobileUI != null)
        {
            mobileUI.SetActive(false);
        }
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        pauseMenuUi.SetActive(false);
    }

    public void OpenInfo()
    {
        infoMenu.SetActive(true);
        pauseMenuUi.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        pauseMenuUi.SetActive(true);
    }

    public void CloseInfo()
    {
        infoMenu.SetActive(false);
        pauseMenuUi.SetActive(true);
    }
}
