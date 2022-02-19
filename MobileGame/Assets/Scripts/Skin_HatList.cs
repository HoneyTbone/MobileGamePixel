using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin_HatList : MonoBehaviour
{
    public List<Sprite> skins = new List<Sprite>();
    public List<Sprite> hats = new List<Sprite>();

    private static Skin_HatList playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
