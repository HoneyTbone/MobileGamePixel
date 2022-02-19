using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollect : MonoBehaviour
{
    StatManager statManager;

    private int currentStars;
    private int chestNumber;
    public Text starsThisLevelText;
    private int starsThisLevel = 0;
    //public Text numberGained;
    public int currentHearts = 0;
    public Text heartAmount;

    void Start()
    {
        currentStars = PlayerPrefs.GetInt("TotalStars", 0);
        PlayerPrefs.SetInt("Hearts", currentHearts);
        statManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<StatManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) // Collides with a collider
    {
        if (collision.gameObject.CompareTag("Star")) // If its the Player
        {
            currentStars++;
            starsThisLevel++;
            statManager.stars = statManager.stars + 1;
            PlayerPrefs.SetInt("TotalStars", currentStars);
            PlayerPrefs.SetInt("StarsThisLevel", starsThisLevel);
            starsThisLevelText.text = PlayerPrefs.GetInt("StarsThisLevel", 0).ToString();
            statManager.UpdateStars();
        }
        if (collision.gameObject.CompareTag("Chest")) // If its the Player
        {
            chestNumber = Random.Range(2, 5);
            currentStars = currentStars + chestNumber;
            starsThisLevel = starsThisLevel + chestNumber;
            statManager.stars = statManager.stars + chestNumber;
            PlayerPrefs.SetInt("TotalStars", currentStars);
            PlayerPrefs.SetInt("StarsThisLevel", starsThisLevel);
            starsThisLevelText.text = PlayerPrefs.GetInt("StarsThisLevel", 0).ToString();
            statManager.UpdateStars();
        }
        if (collision.gameObject.CompareTag("Heart")) // If its the Player
        {
            currentHearts++;
            PlayerPrefs.SetInt("Hearts", currentHearts);
            heartAmount.text = PlayerPrefs.GetInt("Hearts", 0).ToString();
            currentHearts = PlayerPrefs.GetInt("Hearts", 0);

            Debug.Log(currentHearts);
        }

    }
}
