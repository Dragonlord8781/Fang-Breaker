using System.Collections;
using UnityEngine;

public class TempFX : MonoBehaviour
{
    public float delayTime;
    public AudioSource AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource.Play();
        StartCoroutine(DelayedActionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(gameObject);
    }



}