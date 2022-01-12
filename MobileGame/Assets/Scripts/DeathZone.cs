using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Checks if the player has fallen off the screen */

public class DeathZone : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Started");
    }
    private void OnCollisionEnter2D(Collision2D collision) // When Collides with something
    {
        if (collision.gameObject.CompareTag("Player")) // If that something is the player
        {
            //Debug.Log("Dead");
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name); // reload the scene
        }
    }
}
