using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class GunDamageScript : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;
    public CoreGunScript CoreGunScript;
    private float xPosition;
    private float yPosition;
    private float zPosition;
    private float ranX;
    private float ranY;
    private float ranZ;

    private Vector3 randomPosition;

    private Vector3 hitSpot;

    public GameObject hitMarker;
    public float delayTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    void Update()
    {
        xPosition = PlayerCamera.position.x;
        yPosition = PlayerCamera.position.y;
        zPosition = PlayerCamera.position.z;
    }

    public void Shoot()
    {

     
        if (CoreGunScript.isShotgun == true)
        {
            for (int i = 1; i <= CoreGunScript.pelletCount; i++)
            {
                RandomPosition();

                Ray pelletRay = new Ray(randomPosition, PlayerCamera.forward);

                Debug.DrawRay(randomPosition, PlayerCamera.forward, Color.yellow, 2);
                Debug.Log("Shot Pellet at " + randomPosition);

                if (Physics.Raycast(pelletRay, out RaycastHit hitInfo2, BulletRange))
                {
                    if (hitInfo2.collider.gameObject.TryGetComponent(out EntityHealthScript enemy))
                    {

                        enemy.Health -= Damage;
                        hitMarker.SetActive(true);
                        StartCoroutine(DelayedActionCoroutine());

                    }

                    hitSpot = hitInfo2.point;

                }
            }
        }
        else
        {
            RandomPosition();

            Ray gunRay = new Ray(randomPosition, PlayerCamera.forward);

            Debug.DrawRay(randomPosition, PlayerCamera.forward, Color.yellow, 2);

            if (Physics.Raycast(gunRay, out RaycastHit hitInfo3, BulletRange))
            {
                if (hitInfo3.collider.gameObject.TryGetComponent(out EntityHealthScript enemy))
                {
                    enemy.Health -= Damage;
                    hitMarker.SetActive(true);
                    StartCoroutine(DelayedActionCoroutine());

                    Debug.Log("Shot bullet at " + randomPosition);
                }

              
            }
        }
    }

    private IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        hitMarker.SetActive(false);
    }

    public void RandomPosition()
    {
        ranX = Random.Range(xPosition - CoreGunScript.pelletSpread, xPosition + CoreGunScript.pelletSpread);
        ranY = Random.Range(yPosition - CoreGunScript.pelletSpread, yPosition + CoreGunScript.pelletSpread);
        ranZ = Random.Range(zPosition - CoreGunScript.pelletSpread, zPosition + CoreGunScript.pelletSpread);

        randomPosition = new Vector3(ranX, ranY, ranZ);


    }
}
