using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamageScript : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange)) 
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out EntityHealthScript enemy))
            {
                enemy.Health -= Damage;
            }
        }
    }
}
