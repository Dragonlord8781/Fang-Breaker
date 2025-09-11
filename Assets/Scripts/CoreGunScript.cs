using UnityEngine.Events;
using UnityEngine;

public class CoreGunScript : MonoBehaviour
{
    public UnityEvent OnGunShoot; //creates OnGunShoot UnityEvent
    public float FireCoolDown; //creates FireCoolDown float

    public bool Automatic; //creates Automatic bool

    private float CurrentCooldown; //creates CurrentCoolDown float

    public Animator anim; //creates anim Animator

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCooldown = FireCoolDown;

        anim = GetComponent<Animator>();
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

                anim.SetTrigger("PlayAnimation");
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
}
