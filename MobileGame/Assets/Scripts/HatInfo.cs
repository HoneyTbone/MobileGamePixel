using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Hat", menuName = "Create New Hat")]
public class HatInfo : ScriptableObject
{
    public enum HatIDs {blackBandana, redBandana, blueBandana, yellowBandana, greenBandana, blackBallCap, redBallCap, yellowBallCap, greenBallCap, blueBallCap, EyePatch, halo, propBallCap, skiMask, antlers, bunnyEars, chef, cowboy, jester, leperchaun, magic, pirate, police, santa, spartan, top, viking, navy, greenMohawk, redMohawk, blueMohawk, fireHelmet, fedora, witch, armyHat, pinkSkiMask, camo, pinkCamo, headphones, tshirt}
    public HatIDs hatID;

    public Sprite hatSprite;

    public int hatPrice;
}
