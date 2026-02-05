using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthScript : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    private float health;

    public int scorePoints;

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
                PlayerManager.Instance.AddPoints(scorePoints);
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
