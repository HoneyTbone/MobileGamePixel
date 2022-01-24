using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin_HatList : MonoBehaviour
{
    public List<Sprite> skins = new List<Sprite>();
    public List<Sprite> hats = new List<Sprite>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
