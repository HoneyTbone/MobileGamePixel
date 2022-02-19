using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public GameObject FX;
    public AudioClip clip;
    public bool usesFX;
    public bool usesSound;

    private void OnTriggerEnter2D(Collider2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Player")) // If its the Player
        {
            if(usesFX == true)
            {
                Instantiate(FX, transform.position, Quaternion.identity);
            }
            if(usesSound == true)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, 0f);
            }
            Destroy(gameObject);
        }

    }
}
