using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{

    public float jumpForce = 10f; // speed the player moves when hitting the object
    private SpriteRenderer itemImage; // reference to the special Item

    public GameObject effectFX; // Reference to the effects
    private Vector3 locationFXSpawn; // Where the effects spawn

    private BoxCollider2D Coll2D;

    public bool aboveOnly;
    public bool doesDelete;

    public float timeToWait;
    private float newTime;


    PlayerController playerController; // Reference to the player controller script

    private void OnCollisionEnter2D(Collision2D collision) // Collides with something
    {
        if (collision.gameObject.CompareTag("Player")) // If it is the player
        {
            if (playerController.checkingForItems == true)
            {
                if (aboveOnly == true)
                {
                    if (collision.relativeVelocity.y <= 0f) // Is the player falling
                    {
                        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                        Vector2 velocity = rb.velocity;
                        velocity.y = jumpForce;
                        rb.velocity = velocity;
                        Instantiate(effectFX, locationFXSpawn, Quaternion.identity);
                        // adds the velocity to the player
                        StartCoroutine(switchMoveDisable());
                        //disableColl();
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
                    StartCoroutine(switchMoveDisable());
                    //disableColl();
                }
            }
        }
    }
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Finds a reference to the player
        itemImage = GetComponent<SpriteRenderer>(); // Reference to the sprite of the itemImage
        locationFXSpawn = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z); // where to spawn the effects
        Coll2D = GetComponent<BoxCollider2D>(); // Finds the collider
    }

    IEnumerator switchMoveDisable()
    {
        //Debug.Log("Hit");
       
            playerController.Coll2D.enabled = false;
            playerController.checkingForEnemies = false;
            playerController.checkingForItems = false;
            if (doesDelete == true)
            {
                itemImage.enabled = false;
            }
            // Debug.Log("Find");
            yield return new WaitForSecondsRealtime(0.1f);
            playerController.Coll2D.enabled = true;
            yield return new WaitForSecondsRealtime(timeToWait);
            // Debug.Log("found");
            //playerController.Coll2D.enabled = true;
            playerController.checkingForEnemies = true;
            playerController.checkingForItems = true;
            if (doesDelete == true)
            {
                Destroy(gameObject);
            }
            //after 3.5 seconds re enables the collider
    }
    void FixedUpdate()
    {
        if(playerController.checkingForItems == false)
        {
            Coll2D.enabled = false;
        }
        if (playerController.checkingForItems == true)
        {
            Coll2D.enabled = true;
        }
    }
}
