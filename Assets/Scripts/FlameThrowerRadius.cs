using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerRadius : MonoBehaviour
{
    public bool burningEnemy;
    private float fireDamage;
    public GunDamageScript Source;

    private List<GameObject> EnemiesInRadius = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireDamage = Source.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in EnemiesInRadius)
        {
            if (obj != null && obj.TryGetComponent(out EntityHealthScript enemyHealth))
            {
                enemyHealth.Health -= fireDamage;
                if (enemyHealth.Health < 0)
                {
                    EnemiesInRadius.Remove(obj);
                }

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            burningEnemy = true;
            EnemiesInRadius.Add(collision.gameObject);
            Debug.Log("burning enemies");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        EnemiesInRadius.Remove(other.gameObject);

    }
}
