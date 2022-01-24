using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Checks if the player has fallen off the screen */

public class DeathZone : MonoBehaviour
{
    StarCollect starCollect;
    StatManager statManager;

    void Start()
    {
        //Debug.Log("Started");
        starCollect = GameObject.FindGameObjectWithTag("Player").GetComponent<StarCollect>(); // Finds the player within the scene
        statManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<StatManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // When Collides with something
    {
        if (collision.gameObject.CompareTag("Player")) // If that something is the player
        {
            checkDeath();
        }
    }
    void checkDeath()
    {
        if (starCollect.currentHearts <= 0)
        {
            statManager.deaths++;
            statManager.LevelEnd();
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name); // reload the scene
        }
        else if (starCollect.currentHearts > 0)
        {
            statManager.deaths++;
            starCollect.currentHearts--;
            PlayerPrefs.SetInt("Hearts", starCollect.currentHearts);
            starCollect.heartAmount.text = PlayerPrefs.GetInt("Hearts", 0).ToString();
        }
    }
}
