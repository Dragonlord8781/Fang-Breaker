using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI; 

public class PlayerManager : MonoBehaviour
{
    private int currentPoints;
    public TextMeshProUGUI scoreText;

    private static PlayerManager _instance;
    public static PlayerManager Instance { get {  return _instance; } }

    public Slider healthSlider;

    public EntityHealthScript healthScript;

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
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentPoints.ToString();
        healthSlider.value = healthScript.Health;
    }

    public void AddPoints(int pointsToAdd)
    {
        currentPoints += pointsToAdd;
    }

    internal static void AddPoints()
    {
        throw new NotImplementedException();
    }
}
