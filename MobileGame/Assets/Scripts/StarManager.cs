using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Text starAmount;
    public int currentStars = 0;

    // Start is called before the first frame update
    void Start()
    { 
        currentStars = PlayerPrefs.GetInt("TotalStars", 0);
        starAmount.text = currentStars.ToString();   
    }

}
