using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Allows the player to move side to side when the phone is tilted */

public class PlayerController : MonoBehaviour
{
    StatManager statManager;

    public float speed; // How fast the player moves
    private Rigidbody2D rb; // Reference to the players rigid body
    private Vector2 characterVelocity; 
    public bool movement = true;

    public bool checkingForEnemies = true;
    public bool checkingForItems = true;

    //public bool needs platformReset = false;

    public BoxCollider2D Coll2D; // Reference to the players collider

    public Transform playerArtTransform; //Reference to the art

    private float moveX;

    private bool dead = false;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Finds the Rigid Body
        Coll2D = GetComponent<BoxCollider2D>(); // Finds the collider
        statManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.acceleration.x * speed; // Gets the speed and direction at which the player needs to move
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -3.8f, 3.8f), transform.position.y); // sets the players new poslition
    }

    void FixedUpdate()
    {
        if(movement == true) // What to do if the player movess
        {
            characterVelocity = new Vector2(moveX * speed, rb.velocity.y);
            rb.velocity = characterVelocity;
        }   
        if(movement == false) // what happens when the player doesnt move
        {
            if(dead == false)
            {
                StartCoroutine(death());
                dead = true;
            }
        }
        if(moveX < -0.05f) // Rotates the art
        {
            playerArtTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveX > 0.05f) // Rotates the art

        {
            playerArtTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    IEnumerator death()
    {
        Debug.Log("Hit");
        Coll2D.enabled = false;
        statManager.deaths++;
        statManager.LevelEnd();
        yield return new WaitForSecondsRealtime(3f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name); // reload the scene
    }

}
