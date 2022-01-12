using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public GameObject FX;
    public bool usesFX;

    private void OnTriggerEnter2D(Collider2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Player")) // If its the Player
        {
            if(usesFX == true)
            {
                Instantiate(FX, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

    }
}
