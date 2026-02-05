using UnityEngine;
using TMPro;
using System;

public class PlayerManager : MonoBehaviour
{
    private int currentPoints;
    public TextMeshProUGUI scoreText;

    private static PlayerManager _instance;
    public static PlayerManager Instance { get {  return _instance; } }

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
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentPoints.ToString();
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
