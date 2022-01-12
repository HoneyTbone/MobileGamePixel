using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Allows the player to bounce off the platforms */

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f; // The Height the player jumps when he lands on the platform
    private Transform checker; // reference to the checker on the player

    private Vector3 locationFXSpawn;
    public GameObject effectFX; // Reference to the spawn for the Effect if used when the player hits the platform
    public bool usesFX = false;
    public bool isBreakable = false; // does the platform break?

    private void OnCollisionEnter2D(Collision2D collision) // Collides with object
    {
        if(collision.relativeVelocity.y <= 0f) // Is the player falling
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            { // adds velocity to the player
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                if(usesFX == true)
                {
                    Instantiate(effectFX, locationFXSpawn, Quaternion.identity); // spawns effect if used
                }     
                if (isBreakable == true)
                {
                    Destroy(gameObject); // breaks platform if checked when hit
                }
            }
        }
        
    }
    void Start()
    {
        locationFXSpawn = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z); // Where to spawn the effects
        checker = GameObject.FindWithTag("Checker").transform; // Finds the platform checker
    }
    // Update is called once per frame
    void Update()
    {
      if(transform.position.y <= checker.position.y) // if the platform is low enough off the screen, delete the platform
        {
            Destroy(gameObject);
        }
    }
}
