using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUnlockables : MonoBehaviour
{
    public SkinInfo skinInfo;
    public HatInfo hatInfo;
    Skin_HatList skinList;
    public bool isSkinUnlocked;
    public bool isHatUnlocked;
    public bool checkHat;
    public bool checkSkin;

    // Start is called before the first frame update
    private void Awake()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if(checkHat == true)
        {
            if (PlayerPrefs.GetInt(hatInfo.hatID.ToString()) == 1)
            {
                isHatUnlocked = true;
                if (!skinList.hats.Contains(hatInfo.hatSprite))
                {
                    skinList.hats.Add(hatInfo.hatSprite);
                }
            }
        }
        if(checkSkin == true)
        {
            if (PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1)
            {
                isSkinUnlocked = true;
                if (!skinList.skins.Contains(skinInfo.skinSprite))
                {
                    skinList.skins.Add(skinInfo.skinSprite);
                }
            }
        }

    }
}
