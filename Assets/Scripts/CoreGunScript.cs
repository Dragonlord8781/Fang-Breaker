using UnityEngine.Events;
using UnityEngine;

public class CoreGunScript : MonoBehaviour
{
    public UnityEvent OnGunShoot; //creates OnGunShoot UnityEvent
    public float FireCoolDown; //creates FireCoolDown float

    public bool Automatic; //creates Automatic bool

    private float CurrentCooldown; //creates CurrentCoolDown float

    public Animator anim; //creates anim Animator

    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CurrentCooldown = FireCoolDown;

        anim = GetComponent<Animator>();

        bulletsLeft = magazineSize;
    }

    void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
    }

    void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !isReloading)
        {
            Reload();
        }
        if (bulletsLeft > 0)
        {
            if (Automatic)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (CurrentCooldown <= 0f)
                    {
                        OnGunShoot?.Invoke();
                        CurrentCooldown = FireCoolDown;
                        bulletsLeft--;
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
                        bulletsLeft--;
                    }

                    anim.SetTrigger("PlayAnimation");
                }
            }
        }
        else
        {
          
        }
        CurrentCooldown -= Time.deltaTime;
    }
}
