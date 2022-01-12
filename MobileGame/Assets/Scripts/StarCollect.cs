using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarCollect : MonoBehaviour
{
    private int currentStars;
    private int chestNumber;
    public Text starsThisLevelText;
    private int starsThisLevel = 0;
    //public Text numberGained;
    private int currentHearts = 0;

    void Start()
    {
        currentStars = PlayerPrefs.GetInt("TotalStars", 0);
        PlayerPrefs.SetInt("Hearts", currentHearts);
    }
    private void OnTriggerEnter2D(Collider2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Star")) // If its the Player
        {
            currentStars++;
            starsThisLevel++;
            PlayerPrefs.SetInt("TotalStars", currentStars);
            PlayerPrefs.SetInt("StarsThisLevel", starsThisLevel);
            starsThisLevelText.text = PlayerPrefs.GetInt("StarsThisLevel", 0).ToString();
        }
        if (collision.gameObject.CompareTag("Chest")) // If its the Player
        {
            chestNumber = Random.Range(3, 7);
            currentStars = currentStars + chestNumber;
            starsThisLevel = starsThisLevel + chestNumber;
            PlayerPrefs.SetInt("TotalStars", currentStars);
            PlayerPrefs.SetInt("StarsThisLevel", starsThisLevel);
            starsThisLevelText.text = PlayerPrefs.GetInt("StarsThisLevel", 0).ToString();
        }
        if (collision.gameObject.CompareTag("Heart")) // If its the Player
        {
            currentHearts++;
            PlayerPrefs.SetInt("Hearts", currentHearts);
            Debug.Log(currentHearts);
        }

    }
}
