using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI; 

public class PlayerManager : MonoBehaviour
{
    public int currentPoints;
    public TextMeshProUGUI scoreText;

    private static PlayerManager _instance;
    public static PlayerManager Instance { get {  return _instance; } }

    public Slider healthSlider;

    public EntityHealthScript healthScript;

    private GameObject currentWeapon;

    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammoCount;

    private int currentAmmoCount;
    private int totalAmmoCount;

    private CoreGunScript weaponInfo;

 

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + currentPoints.ToString();

        healthSlider.maxValue = healthScript.Health; 
        healthSlider.value = healthScript.Health;

        WeaponUI();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentPoints.ToString();
        healthSlider.value = healthScript.Health;

        WeaponUI();
    }

    public void AddPoints(int pointsToAdd)
    {
        currentPoints += pointsToAdd;
    }

    internal static void AddPoints()
    {
        throw new NotImplementedException();
    }

    void WeaponUI()
    {
        currentWeapon = GameObject.FindGameObjectWithTag("Weapon");

        weaponInfo = currentWeapon.GetComponent<CoreGunScript>();

        weaponName.text = currentWeapon.name;

        currentAmmoCount = weaponInfo.bulletsLeft;
        totalAmmoCount = weaponInfo.magazineSize;

        ammoCount.text = currentAmmoCount + "/" + totalAmmoCount;
    }
}
