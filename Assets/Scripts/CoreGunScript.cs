using UnityEngine.Events;
using UnityEngine;

public class CoreGunScript : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public bool automatic;

    private float currentCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCooldown = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
