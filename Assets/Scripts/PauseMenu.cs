using StarterAssets;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
   

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
        Time.timeScale = 1f;
  
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
 
    }
}
