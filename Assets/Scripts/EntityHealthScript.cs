using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthScript : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float health;

    public int scorePoints;

    public bool isEnemy;
    public bool isPlayer;

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
                PlayerData.Instance.AddPoints(scorePoints);

                if (isEnemy)
                {
                    PlayerData.Instance.AddKill(1);
                }
                if (isPlayer)
                {
                    PlayerData.Instance.DeathAddUp();
                }
                Destroy(gameObject);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = StartingHealth;
    }
}
