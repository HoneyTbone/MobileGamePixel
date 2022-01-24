using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatInShop : MonoBehaviour
{
    public HatInfo hatInfo;

    public Text buttonText;
    public Text priceText;
    public Image hatImage;
    Skin_HatList skinList;

    public bool isHatUnlocked;

    // Start is called before the first frame update
    private void Awake()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
        priceText.text = hatInfo.hatPrice.ToString();
        hatImage.sprite = hatInfo.hatSprite;
        IsHatUnlocked(); 
    }

    private void IsHatUnlocked()
    {
        if (PlayerPrefs.GetInt(hatInfo.hatID.ToString()) == 1)
        {
            isHatUnlocked = true;
            buttonText.text = "Owned";
            if (!skinList.hats.Contains(hatInfo.hatSprite))
            {
                skinList.hats.Add(hatInfo.hatSprite);
            }
        }
    }

    public void OnButtonPress()
    {
        if(isHatUnlocked)
        {
            //owned
        }
        else
        {
            if(FindObjectOfType<ShopCurrencyChecker>().TryRemoveStars(hatInfo.hatPrice))
            { 
                PlayerPrefs.SetInt(hatInfo.hatID.ToString(), 1);
                IsHatUnlocked();
            }
        }
    }
    
}
