using UnityEngine;
using StarterAssets;

public class MouseController : MonoBehaviour
{

    public StarterAssetsInputs controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = controls.look;
    }
}
