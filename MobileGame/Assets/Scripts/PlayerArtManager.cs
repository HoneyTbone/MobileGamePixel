using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtManager : MonoBehaviour
{
    private int hatSkin;
    private int skinSkin;
    public SpriteRenderer hatArt;
    public SpriteRenderer skinArt;

    Skin_HatList skinList;

    void Awake()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
    }
    // Start is called before the first frame update
    void Start()
    {
        skinSkin = PlayerPrefs.GetInt("skinIndex");
        hatSkin = PlayerPrefs.GetInt("hatIndex");
        hatArt.sprite = skinList.hats[hatSkin];
        skinArt.sprite = skinList.skins[skinSkin];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
