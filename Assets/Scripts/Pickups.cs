using UnityEngine;

public class Pickups : MonoBehaviour
{
    public EntityHealthScript healthScript;

    public int healthValue;

    private bool touchingPlayer;

    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer)
        {
            AddHealth();
        }
    }
     

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingPlayer = true;
            player = collision.gameObject;
            Debug.Log("Touching player");
        }
        else
        {
            touchingPlayer = false;
        }
    }

    public void AddHealth()
    {
        if (player.TryGetComponent(out EntityHealthScript healthScript))
        {
            healthScript.Health += healthValue;
          
        }
    }
}
