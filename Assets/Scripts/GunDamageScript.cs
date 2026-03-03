using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject enemyHit;
    public GameObject terrianHit;

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

                if (Physics.Raycast(pelletRay, out RaycastHit hitInfo, BulletRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out EntityHealthScript enemy))
                    {
                        enemy.Health -= Damage;

                        //Instantiate(enemyHit,, Quaternion.identity);
                    }
                }
            }
        }
        else
        {
            Ray gunRay = new Ray(randomPosition, PlayerCamera.forward);

            Debug.DrawRay(randomPosition, PlayerCamera.forward, Color.yellow, 2);

            if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out EntityHealthScript enemy))
                {
                    enemy.Health -= Damage;
                }
            }
        }
    }

    public void RandomPosition()
    {
        ranX = Random.Range(xPosition - CoreGunScript.pelletSpread, xPosition + CoreGunScript.pelletSpread);
        ranY = Random.Range(yPosition - CoreGunScript.pelletSpread, yPosition + CoreGunScript.pelletSpread);
        ranZ = Random.Range(zPosition - CoreGunScript.pelletSpread, zPosition + CoreGunScript.pelletSpread);

        randomPosition = new Vector3(ranX, ranY, ranZ);
    }
}
