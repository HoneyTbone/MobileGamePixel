using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A tracker for if the player has hit an enemy
 * If so then the players collider is disabled
 * allowing him to fall */

public class Enemy : MonoBehaviour
{
    private int currentHearts = 0;
    PlayerController playerController; // Reference to the PlayerController Script
    public GameObject bloodFX; // Reference to a Blood Effect
    public bool above; // Does this only work when you land on it?
    private BoxCollider2D Coll2D; // Reference to the enemies collider

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
        currentHearts = PlayerPrefs.GetInt("Hearts", 0);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Finds the player within the scene
        Coll2D = GetComponent<BoxCollider2D>(); // Finds the collider
    }

    IEnumerator HitSomething()
    {
        //Debug.Log("Hit");
        Coll2D.enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        Coll2D.enabled = true;
    }

    void checkDeath()
    {
        currentHearts = PlayerPrefs.GetInt("Hearts", 0);
        Instantiate(bloodFX, transform.position, Quaternion.identity); // Spawns the blood
        if (currentHearts <= 0)
        {
            playerController.movement = false;
        }
        else if (currentHearts > 0)
        {
            currentHearts--;
            PlayerPrefs.SetInt("Hearts", currentHearts);
            StartCoroutine(HitSomething());
        }
    }
}
