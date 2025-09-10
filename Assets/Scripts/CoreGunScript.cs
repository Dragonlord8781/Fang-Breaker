using UnityEngine.Events;
using UnityEngine;

public class CoreGunScript : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCoolDown;

    public bool Automatic;

    private float CurrentCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCooldown = FireCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                if(CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCoolDown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCoolDown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
}
