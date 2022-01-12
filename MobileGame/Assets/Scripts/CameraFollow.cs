using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Allow the Camera to slow follow the player, to keep him on the screen */

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the Player Transform

    private void LateUpdate() // Updates Late to add drag, so the camera is not stuck to the player
    {
        if(target.position.y > transform.position.y) // Checks if the Player.Y is Greater than Camera.Y
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z); 
            transform.position = newPosition;
            // Sets the Camera to the players new Y position
        }
    }
}
