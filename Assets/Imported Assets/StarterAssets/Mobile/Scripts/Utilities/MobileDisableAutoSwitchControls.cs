

using UnityEngine;

using UnityEngine.InputSystem;


public class MobileDisableAutoSwitchControls : MonoBehaviour
{

#if (UNITY_IOS || UNITY_ANDROID)

#else
    
    public void Start()
    {
        Destroy(gameObject);
    }
    

#endif

}
