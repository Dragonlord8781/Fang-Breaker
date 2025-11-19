using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

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

    public GameObject thisGun;
    public GameObject nextGun;

    public float delayTime;

    private bool isEmpty;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CurrentCooldown = FireCoolDown;

        anim = GetComponent<Animator>();

        bulletsLeft = magazineSize;

        anim.SetTrigger("PlayUnhoister");

        isEmpty = false;
    }

    void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
        anim.SetTrigger("PlayReload");
        Debug.Log("Gun is Reloading");
    }

    void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
        isEmpty = false;
        anim.SetTrigger("PlayFull");
    }

    void Empty()
    {
        anim.SetTrigger("PlayEmpty");
        Debug.Log("Gun is Empty");
        isEmpty = true;
    }

    void SwitchGun()
    {
        anim.SetTrigger("PlayHoister");

        StartCoroutine(DelayedActionCoroutine());
    }

    private IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        thisGun.SetActive(false);

        nextGun.SetActive(true);
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

                    anim.SetTrigger("PlayShoot");
                }
            }
        }
        else if (bulletsLeft < 1 && !isReloading && !isEmpty) 
        {
            Empty();
        }
        CurrentCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchGun();
        }
    }

   
}
