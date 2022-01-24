using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levels;
    public GameObject[] locks;
    public GameObject[] levelText;

    public Text unlockAmount;
    private float unlockNumber;
    private int nextLevelNumber = 2;

    private float TotalDistance;

    // Start is called before the first frame update
    void Start()
    {
        TotalDistance = PlayerPrefs.GetFloat("TotalDistance", 0);
        CheckUnlocked();
        LevelTextNumber();
    }

    void CheckUnlocked()
    {
        nextLevelNumber = 7;
        if (TotalDistance < 75000f)
        {
            levels[4].interactable = false;
            locks[4].SetActive(true);
            levelText[4].SetActive(false);
            nextLevelNumber = 6;
        }
        if (TotalDistance < 35000f)
        {
            levels[3].interactable = false;
            locks[3].SetActive(true);
            levelText[3].SetActive(false);
            nextLevelNumber = 5;
        }
        if (TotalDistance < 15000f)
        {
            levels[2].interactable = false;
            locks[2].SetActive(true);
            levelText[2].SetActive(false);
            nextLevelNumber = 4;
        }
        if (TotalDistance < 5000f)
        {
            levels[1].interactable = false;
            locks[1].SetActive(true);
            levelText[1].SetActive(false);
            nextLevelNumber = 3;
        }
        if (TotalDistance < 1500f)
        {
            levels[0].interactable = false;
            locks[0].SetActive(true);
            levelText[0].SetActive(false);
            nextLevelNumber = 2;
        }
    }
    
    void LevelTextNumber()
    {
        if(nextLevelNumber == 2)
        {
            unlockNumber = 1500f - TotalDistance;
        }
        if (nextLevelNumber == 3)
        {
            unlockNumber = 5000f - TotalDistance;
        }
        if (nextLevelNumber == 4)
        {
            unlockNumber = 15000f - TotalDistance;
        }
        if (nextLevelNumber == 5)
        {
            unlockNumber = 35000f - TotalDistance;
        }
        if (nextLevelNumber == 6)
        {
            unlockNumber = 75000f - TotalDistance;
        }
        unlockAmount.text = unlockNumber.ToString();
        if (nextLevelNumber == 7)
        {
            unlockAmount.text = "More Coming Soon";
        }
        
    }
}
