using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static Unity.VisualScripting.Member;

public class FlameThrowerRadius : MonoBehaviour
{
    public bool burningEnemy;
    public float fireDamage;
    public GunDamageScript Source;
    public GameObject fire;
    public GameObject fireTarget;

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
            if (obj != null && obj.TryGetComponent(out EnemyAiScript enemyCode) && obj.TryGetComponent(out EntityHealthScript enemyHealth))
            {
                if (enemyCode.isArtic == true)
                {
                    enemyHealth.Health -= fireDamage * 2 * Time.deltaTime;
                }
                else
                {
                    enemyHealth.Health -= fireDamage * Time.deltaTime;
                }

                enemyHealth.Health -= fireDamage * Time.deltaTime;
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
            fireTarget = collision.gameObject;
            Instantiate(fire, collision.transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        EnemiesInRadius.Remove(other.gameObject);
    }
}
