using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A tracker for if the player has hit an enemy
 * If so then the players collider is disabled
 * allowing him to fall */

public class Enemy : MonoBehaviour
{
    PlayerController playerController; // Reference to the PlayerController Script
    StarCollect starCollect;
    public GameObject bloodFX; // Reference to a Blood Effect
    public bool above; // Does this only work when you land on it?

    private void OnCollisionEnter2D(Collision2D collision) // Collides with a collider
    {
        if(collision.gameObject.CompareTag("Player")) // If its the Player
        {
            if(above == false) // Works when hit at any angle
            {
                checkDeath();

            }
            if(above == true)
            {
                if (collision.relativeVelocity.y <= 0f) // if the vecolicty is <= 0 then the player is falling on the enemy
                {
                    checkDeath();
                }
            }
            
        }
                
    }
    private void OnTriggerEnter2D(Collider2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Player")) // If its the Player
        {
            checkDeath();
        }

    }
    void Start() // called at scene start
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Finds the player within the scene
        starCollect = GameObject.FindGameObjectWithTag("Player").GetComponent<StarCollect>(); // Finds the player within the scene
    }


    void checkDeath()
    {
        if(playerController.checkingForEnemies == true)
        {
            Instantiate(bloodFX, transform.position, Quaternion.identity); // Spawns the blood
            if (starCollect.currentHearts <= 0)
            {
                playerController.movement = false;
            }
            else if (starCollect.currentHearts > 0)
            {
                Destroy(gameObject);
                starCollect.currentHearts--;
                PlayerPrefs.SetInt("Hearts", starCollect.currentHearts);
                starCollect.heartAmount.text = PlayerPrefs.GetInt("Hearts", 0).ToString();
            }
        } 
    }
}
