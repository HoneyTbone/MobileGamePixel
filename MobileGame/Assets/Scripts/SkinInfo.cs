using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject
{
    public enum SkinIDs { zombie, robot, army, ghost, penguin, blackCat, greyCat, calicoCat, cyclops, redShirt, yellowShirt, greenShirt, fireElemental, waterElemental, goblin, minotaur, monkey, blueNinja, redNinja, yellowNinja, greenNinja, mummy, dinosaur, whiteNinja, unicorn, turtle, }
    public SkinIDs skinID;

    public Sprite skinSprite;

    public int skinPrice;
}
