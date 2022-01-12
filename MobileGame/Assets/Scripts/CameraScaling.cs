using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sets the camera size to fit the screen size */

public class CameraScaling : MonoBehaviour
{ 
   
 void Start () {
       // Debug.Log(Camera.main.aspect);
       // Debug.Log(Camera.main.orthographicSize);
        
        setLocation(); // Calls the Function when the scene is loaded

    }
    void setLocation() // Sets the Size of the camera based on the size of the screen using the Aspect Ratio
    {
        if (Camera.main.aspect > 0.6)
        {
            Debug.Log("2:3");
            Camera.main.orthographicSize = 5.964078f;
        }
        else if (Camera.main.aspect > 0.55)
        {
            Debug.Log("9:16");
            Camera.main.orthographicSize = 7.07f;
        }
        else if (Camera.main.aspect > 0.49)
        {
            Debug.Log("9:18");
            Camera.main.orthographicSize = 7.96694f;

        }
        else if (Camera.main.aspect > 0.46)
        {
            Debug.Log("9:19");
            Camera.main.orthographicSize = 8.406063f;

        }
        // outputs the closest aspect ratio to the console
    }
}
