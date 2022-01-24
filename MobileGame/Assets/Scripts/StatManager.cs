using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public Transform player;

    private float distance;
    public int stars;
    private float times;
    public int deaths;

    private float score;

    void Start()
    {
        deaths = PlayerPrefs.GetInt("TotalDeaths", 0);
        times = PlayerPrefs.GetFloat("TotalPlayTime", 0);
        stars = PlayerPrefs.GetInt("StarsCollected", 0);
        distance = PlayerPrefs.GetFloat("TotalDistance", 0);
    }
    void FixedUpdate()
    {
        times = times + Time.deltaTime;
        if (player.position.y > score)
        {
            score = Mathf.Floor(player.position.y);
        }
    }

    // Update is called once per frame
    public void LevelEnd()
    {
        times = Mathf.Floor(times);
        PlayerPrefs.SetFloat("TotalPlayTime", times);
        distance = distance + Mathf.Floor(score);
        PlayerPrefs.SetFloat("TotalDistance", distance);
        PlayerPrefs.SetInt("StarsCollected", stars);
        PlayerPrefs.SetInt("TotalDeaths", deaths);
    }
}
