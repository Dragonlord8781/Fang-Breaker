using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class EntityHealthScript : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float health;

    public int scorePoints;

    public bool isPlayer;

    private GameObject killMarker;
    public float delayTime;

    //sets up health system
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            Debug.Log(health);

            if (health <= 0f)
            {
                if (isPlayer)
                {
                    PlayerData.Instance.DeathAddUp();
                    SceneManager.LoadScene("Death Screen");
                }
                else
                {
                    PlayerData.Instance.AddPoints(scorePoints);
                    PlayerData.Instance.AddKill(1);
                    Destroy(gameObject);
                }
            }
        }
    }

 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = StartingHealth;
        killMarker = GameObject.Find("KillIndicator");
    }
}
