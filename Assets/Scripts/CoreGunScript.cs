using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.InputSystem;
using StarterAssets;

public class CoreGunScript : MonoBehaviour
{
    //creates values 
    public UnityEvent OnGunShoot; //unity event for gun shooting 
    public float FireCoolDown; //the cooldown between shots
    public bool Automatic; //determines if the gun is automatic 
    private float CurrentCooldown; //determine what is the current cooldown time

    public Animator anim; //connects animator

    public float reloadTime;  //the time it takes to reload
    public int magazineSize, bulletsLeft; //the magazine size and the bullets is left in mag
    public bool isReloading; //determines if the gun is reloading

    public GameObject thisGun; //connects to this gun
    public GameObject nextGun; //connects to the next gun 
    public GameObject thisReticle;
    public GameObject nextReticle;

    public float delayTime; //the delay time for switching guns

    private bool isEmpty; //determines if the gun is empty

    public StarterAssetsInputs inputs;

    public bool isShooting;
    public bool isShotgun;

    public float pelletCount;
    public float pelletSpread;

    public GunDamageScript bullerShooter;

    public ParticleSystem bulletCasings;

    // Called when the gun awakes - sets cooldown, animator, magaxine size, isEmpty, and triggers "PlayUnhoister"
    void Awake()
    {
        CurrentCooldown = FireCoolDown;

        anim = GetComponent<Animator>();

        bulletsLeft = magazineSize;

        anim.SetTrigger("PlayUnhoister");

        isEmpty = false;
        isShooting = false;

       
    }
     //Reloads the gun - reloading=true, invoke ReloadCompleted after reloadtime, triggers PlayReload animation, states the "Guns is Reloading" in debug.log
    void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
        anim.SetTrigger("PlayReload");
        Debug.Log("Gun is Reloading");
    }
     //Calls when reload completed - sets bulletsLeft to magazineSize, reloading=false, empty=false, triggers PlayFull animation
    void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
        isEmpty = false;
        anim.SetTrigger("PlayFull");
    }
     //Called when gun is empty - triggers PlayEmpty animation, states "Gun is Empty" in debug.log, isEmpty=true
    void Empty()
    {
        anim.SetTrigger("PlayEmpty");
        Debug.Log("Gun is Empty");
        isEmpty = true;
    }

    //Switches gun, plays PlayHoister animation until after enough time passes to reload
    void SwitchGun()
    {
        anim.SetTrigger("PlayHoister");

        StartCoroutine(DelayedActionCoroutine());
    }
    
    //After delay time deacticates thisGun and activates nextGun
    private IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        thisGun.SetActive(false);
        thisReticle.SetActive(false);

        nextGun.SetActive(true);
        nextReticle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.reload && bulletsLeft < magazineSize && !isReloading) //if R is pressed & there is less than a full mag, and isn't reloading - reload
        {
            Reload();
        }
        if (bulletsLeft > 0) //if there's more bullets left than 0, shoot
        {
            if (Automatic)// if automatic, then shoot with heistation
            {
                if (inputs.shoot)
                {
                    if (CurrentCooldown <= 0f)
                    {
                        bullerShooter.Shoot();
                        CurrentCooldown = FireCoolDown;
                        bulletsLeft--;
                        isShooting = true;

                        bulletCasings.Play();
                    }
                    anim.SetTrigger("PlayShoot");
                }
                else
                {
                    isShooting = false;
                }
            }
            else //if not automatic, shoot normally
            {
                if (inputs.shoot)
                {
                    if (CurrentCooldown <= 0f)
                    {
                        OnGunShoot?.Invoke();
                        CurrentCooldown = FireCoolDown;
                        bulletsLeft--;
                        isShooting = true;
                    }

                    anim.SetTrigger("PlayShoot"); 
                }
                else
                {
                    isShooting = false;
                }
            }
        }
        else if (bulletsLeft < 1 && !isReloading && !isEmpty) //if there is less than 1 bullet and is not reloading nor is empty, play Empty once
        {
            Empty();
        }
        CurrentCooldown -= Time.deltaTime;

        if (inputs.swap) //Switch gun when E is pressed
        {
            SwitchGun();
        }
    }

    
    private void OnDrawGizmosSelected() //if player is selected in play mode, gizmo is shown
    {
        //if left mouse button is clicked, gizmo is red, other wise its white
        if (inputs.shoot)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }

        Gizmos.DrawLine(transform.position, transform.forward * 500f); //draws a gun foward from the gun 500 units

        Debug.Log("Gizmos Active"); //lets us know the Gizmod is on
    }

}
