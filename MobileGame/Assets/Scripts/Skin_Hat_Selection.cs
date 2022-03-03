using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Skin_Hat_Selection : MonoBehaviour
{
    public List<Sprite> skins = new List<Sprite>();
    public List<Sprite> hats = new List<Sprite>();
    private int currentSkin = 0;
    private int currentHat = 0;
    public Image skinImage;
    public Image hatImage;
    //public GameObject hatArt;
    //public GameObject skinArt;
    //public SpriteRenderer hatArtRend;
    //public SpriteRenderer skinArtRend;

    Skin_HatList skinList;

    void Start()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
        skins = skinList.skins;
        hats = skinList.hats;
        currentHat = PlayerPrefs.GetInt("SavedHat", 0);
        currentSkin = PlayerPrefs.GetInt("SavedSkin", 0);
        hatImage.sprite = hats[currentHat];
        skinImage.sprite = skins[currentSkin];
    }
    public void NextSkinOption()
    {
        currentSkin++;
        if (currentSkin == skins.Count)
        {
            currentSkin = 0;
        }
        PlayerPrefs.SetInt("SavedSkin", currentSkin);
        skinImage.sprite = skins[currentSkin];
    }

    public void NextHatOption()
    {
        currentHat++;
        if (currentHat == hats.Count)
        {
            currentHat = 0;
        }
        PlayerPrefs.SetInt("SavedHat", currentHat);
        hatImage.sprite = hats[currentHat];
    }
    //////////////////////////////////////////
    public void BackSkinOption()
    {
        currentSkin--;
        if (currentSkin == -1)
        {
            currentSkin = skins.Count - 1;
        }
        PlayerPrefs.SetInt("SavedSkin", currentSkin);
        skinImage.sprite = skins[currentSkin];
    }

    public void BackHatOption()
    {
        currentHat--;
        if (currentHat == -1)
        {
            currentHat = hats.Count - 1;
        }
        PlayerPrefs.SetInt("SavedHat", currentHat);
        hatImage.sprite = hats[currentHat];
    }

    public void SetPrefab()
    {
        //hatArtRend.sprite = hats[currentHat];
        //skinArtRend.sprite = skins[currentSkin];
        PlayerPrefs.SetInt("skinIndex", currentSkin);
        PlayerPrefs.SetInt("hatIndex", currentHat);
        //PrefabUtility.SaveAsPrefabAsset(hatArt, "Assets/Prefabs/HatArt.prefab");
        //PrefabUtility.SaveAsPrefabAsset(skinArt, "Assets/Prefabs/SkinArt.prefab");
    }
}
