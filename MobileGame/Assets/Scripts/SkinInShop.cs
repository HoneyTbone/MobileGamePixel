using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInShop : MonoBehaviour
{
    public SkinInfo skinInfo;

    public Text buttonText;
    public Text priceText;
    public Image skinImage;
    Skin_HatList skinList;

    public bool isSkinUnlocked;

    // Start is called before the first frame update
    void Awake()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
        priceText.text = skinInfo.skinPrice.ToString();
        skinImage.sprite = skinInfo.skinSprite;
        IsSkinUnlocked(); 
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Owned";
            if (!skinList.skins.Contains(skinInfo.skinSprite))
            {
                skinList.skins.Add(skinInfo.skinSprite);
            }
        }
    }

    public void OnButtonPress()
    {
        if(isSkinUnlocked)
        {
            //owned
        }
        else
        {
            if(FindObjectOfType<ShopCurrencyChecker>().TryRemoveStars(skinInfo.skinPrice))
            { 
                PlayerPrefs.SetInt(skinInfo.skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
    
}
