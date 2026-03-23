using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quit()
    {
        PlayerData.Instance.SavePlayer();
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
