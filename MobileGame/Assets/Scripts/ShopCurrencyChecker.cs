using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCurrencyChecker : MonoBehaviour
{
    public int currentStars;
    public Text starAmount;

    private void Awake()
    {
        currentStars = PlayerPrefs.GetInt("TotalStars", 0);
        starAmount.text = currentStars.ToString();
    }

    public bool TryRemoveStars(int starsToRemove)
    {
        if(currentStars >= starsToRemove)
        {
            currentStars -= starsToRemove;
            PlayerPrefs.SetInt("TotalStars", currentStars);
            starAmount.text = currentStars.ToString();
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
