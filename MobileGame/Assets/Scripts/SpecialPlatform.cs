using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{

    public float jumpForce = 10f; // speed the player moves when hitting the object
    private SpriteRenderer itemImage; // reference to the special Item

    public GameObject effectFX; // Reference to the effects
    private Vector3 locationFXSpawn; // Where the effects spawn

    public bool aboveOnly;
    public bool doesDelete;

    public float timeToWait;


    PlayerController playerController; // Reference to the player controller script

    private void OnCollisionEnter2D(Collision2D collision) // Collides with something
    {
        if (collision.gameObject.CompareTag("Player")) // If it is the player
        {
            if(aboveOnly == true)
            {
                if (collision.relativeVelocity.y <= 0f) // Is the player falling
                {
                    Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                    Instantiate(effectFX, locationFXSpawn, Quaternion.identity);
                    // adds the velocity to the player
                    StartCoroutine(switchMove());
                }            
            }
            else
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                Instantiate(effectFX, locationFXSpawn, Quaternion.identity);
                // adds the velocity to the player
                StartCoroutine(switchMove());
            }
            
            
        }
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Finds a reference to the player
        itemImage = GetComponent<SpriteRenderer>(); // Reference to the sprite of the itemImage
        locationFXSpawn = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z); // where to spawn the effects
    }

    IEnumerator switchMove()
    {
        //Debug.Log("Hit");
        playerController.Coll2D.enabled = false;
        if(doesDelete == true)
        {
            itemImage.enabled = false;
        }
        yield return new WaitForSecondsRealtime(timeToWait);
        playerController.Coll2D.enabled = true;
        if (doesDelete == true)
        {
            Destroy(gameObject);
        }
        //Debug.Log("Hit!");
        //after 3.5 seconds re enables the collider
    }
}
