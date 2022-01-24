using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Gains access to scoring and to highscores and stores them in a database */

public class Score : MonoBehaviour
{
    public Text currentScore;
    private float score = 0f;
    public Text highScore;
    public Text lastScore;
    public Transform player;
    public string Highscore_levelName;
    public string LastScore_levelName;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetFloat(Highscore_levelName, 0).ToString();
        lastScore.text = PlayerPrefs.GetFloat(LastScore_levelName, 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > score)
        {
            score = Mathf.Floor(player.position.y);
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        currentScore.text = score.ToString();
        PlayerPrefs.SetFloat(LastScore_levelName, score);
        if (score > PlayerPrefs.GetFloat(Highscore_levelName, 0))
        {
            PlayerPrefs.SetFloat(Highscore_levelName, score);
            highScore.text = score.ToString();
        }
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(Highscore_levelName);
    }
}
