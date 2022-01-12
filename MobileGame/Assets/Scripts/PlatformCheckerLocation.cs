using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sets the location of the platform checker to stay off the screen */

public class PlatformCheckerLocation : MonoBehaviour
{
    //CameraScaling cameraChecker;
    public Transform platformChecker;

    // Start is called before the first frame update
    void Start()
    {
        //cameraChecker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScaling>();
        setLocation();
        
    }

    // Update is called once per frame
    void setLocation()
    {
        if (Camera.main.aspect > 0.6)
        {
            Debug.Log("2:3");
            platformChecker.position = new Vector3(0f, -6f, 0f);
        }
        else if (Camera.main.aspect > 0.55)
        {
            Debug.Log("9:16");
            platformChecker.position = new Vector3(0f, -6.5f, 0f);
        }
        else if (Camera.main.aspect > 0.49)
        {
            Debug.Log("9:18");
            platformChecker.position = new Vector3(0f, -7.5f, 0f);

        }
        else if (Camera.main.aspect > 0.46)
        {
            Debug.Log("9:19");
            platformChecker.position = new Vector3(0f, -8f, 0f);

        }
    }
}
