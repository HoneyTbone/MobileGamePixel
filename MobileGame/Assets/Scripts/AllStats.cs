using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllStats : MonoBehaviour
{
    private float distance;
    private int stars;
    private float time;
    private int deaths;
    private int totalHats = 0;
    private int totalSkins = 0;

    public Text distanceT;
    public Text starsT;
    public Text timeT;
    public Text deathsT;
    public Text skinsT;
    public Text HatsT;

    Skin_HatList skinList;

    // Start is called before the first frame update
    void Start()
    {
        skinList = GameObject.FindGameObjectWithTag("Unlockables").GetComponent<Skin_HatList>();
        deaths = PlayerPrefs.GetInt("TotalDeaths", 0);
        time = PlayerPrefs.GetFloat("TotalPlayTime", 0);
        stars = PlayerPrefs.GetInt("StarsCollected", 0);
        distance = PlayerPrefs.GetFloat("TotalDistance", 0);
        totalSkins = skinList.skins.Count - 1;
        totalHats = skinList.hats.Count - 1;

        time = time / 60;
        time = Mathf.Floor(time);
        distanceT.text = distance.ToString();
        starsT.text = stars.ToString();
        timeT.text = time.ToString();
        deathsT.text = deaths.ToString();
        skinsT.text = totalSkins.ToString();
        HatsT.text = totalHats.ToString();
    }
}
