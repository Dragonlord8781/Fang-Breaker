using UnityEngine;

public class Pickups : MonoBehaviour
{
    public EntityHealthScript healthScript;

    public int healthValue;



    GameObject player;

    private bool isTouchingGround;

    public GameObject bodyObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f, 1.5f, 0f * Time.deltaTime);
        
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

        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
        else
        {
            isTouchingGround= false;
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
