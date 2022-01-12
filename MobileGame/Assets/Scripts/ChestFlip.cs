using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFlip : MonoBehaviour
{
    public GameObject openChest;
    public GameObject closedChest;

    // Start is called before the first frame update
    void Start()
    {
        openChest.SetActive(false);
        closedChest.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Collides with object
    {
        if (collision.gameObject.CompareTag("Player")) // If its the Player
        {
            openChest.SetActive(true);
            closedChest.SetActive(false);
        }
    }
}
