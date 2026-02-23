using UnityEngine;

public class Burnable : MonoBehaviour
{
    public GameObject prey;
    public FlameThrowerRadius source;
    public GameObject sourceObject;
    public EnemyAiScript preyCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sourceObject = GameObject.Find("AttackRadius");
        source = sourceObject.GetComponent<FlameThrowerRadius>();
        prey = source.fireTarget;
        preyCode = prey.GetComponent<EnemyAiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prey != null)
        {
            transform.position = prey.transform.position;
        }

        if(prey != null && TryGetComponent(out EntityHealthScript preyHealth))
        {
            if (preyCode.isArtic == true)
            {
                preyHealth.Health -= source.fireDamage * 2 * Time.deltaTime;
            }
            else
            {
                preyHealth.Health -= source.fireDamage * Time.deltaTime;
            }
        }

        if (prey == null)
        {
            Destroy(gameObject);
        }
    }
}
