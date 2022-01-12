using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachFlyer : MonoBehaviour
{

    public GameObject flyerArt;
    public float timeToWait;

    private void OnCollisionEnter2D(Collision2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Flyer")) // If its the Player
        {

            StartCoroutine(switchMove());
        }
    }

    IEnumerator switchMove()
    {
        flyerArt.SetActive(true);
        yield return new WaitForSecondsRealtime(timeToWait);
        flyerArt.SetActive(false);
        //Debug.Log("Hit!");
        //after 3.5 seconds re enables the collider
    }

}
