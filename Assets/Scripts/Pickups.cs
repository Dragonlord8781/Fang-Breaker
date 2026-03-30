using UnityEngine;

public class Pickups : MonoBehaviour
{
    public EntityHealthScript healthScript;

    public int healthValue;



    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
     

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
 
            player = collision.gameObject;
            Debug.Log("Touching player");
            AddHealth();
            Destroy(gameObject);
        }
    }

    public void AddHealth()
    {
        if (player.TryGetComponent(out EntityHealthScript healthScript))
        {
            healthScript.Health += healthValue;
            Debug.Log("gave health");
          
        }
    }
}
