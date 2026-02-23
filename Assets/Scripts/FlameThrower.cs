using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public CoreGunScript gunScript;
    public GameObject damager;
    public GameObject flames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damager.SetActive(false);
       flames.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gunScript.isShooting && gunScript.bulletsLeft > 0)
        {
            damager.SetActive(true);
            flames.SetActive(true);
        }
        else
        {
            damager.SetActive(false);
            flames.SetActive(false);
        }
    }
}
