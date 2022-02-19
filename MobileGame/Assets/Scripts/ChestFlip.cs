using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFlip : MonoBehaviour
{
    public GameObject openChest;
    public GameObject closedChest;
    public GameObject largeOpenChest;
    public GameObject largeClosedChest;
    //int chestCheck;

    // Start is called before the first frame update
    void Start()
    {
        //chestCheck = Random.Range(0, 5);
        //Debug.Log(chestCheck);
       /* if(chestCheck <= 1)
        {
            largeOpenChest.SetActive(false);
            largeClosedChest.SetActive(true);
            closedChest.SetActive(false);
        }
        else
        {*/
            openChest.SetActive(false);
            closedChest.SetActive(true);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) // Collides with object
    {
        if (collision.gameObject.CompareTag("Player")) // If its the Player
        {
            /*if (chestCheck <= 1)
            {
                largeOpenChest.SetActive(true);
                largeClosedChest.SetActive(false);
            }
            else
            {*/
                openChest.SetActive(true);
                closedChest.SetActive(false);
            //}
        }
    }
}
