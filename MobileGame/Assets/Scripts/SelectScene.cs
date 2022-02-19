using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Allows UI buttons to call functions,
 * that selects scenes or pause/unpause the game */

public class SelectScene : MonoBehaviour
{
   public void SelectDayLevel()
    {
        SceneManager.LoadScene("01Day");
    }
    public void SelectNightLevel()
    {
        SceneManager.LoadScene("02Night");
    }
    public void SelectSunsetLevel()
    {
        SceneManager.LoadScene("03Sunset");
    }
    public void SelectSnowLevel()
    {
        SceneManager.LoadScene("04Snow");
    }
    public void SelectSpaceLevel()
    {
        SceneManager.LoadScene("05Space");
    }
    public void SelectDesertLevel()
    {
        SceneManager.LoadScene("06Desert");
    }
    public void SelectOceanLevel()
    {
        SceneManager.LoadScene("07Ocean");
    }
    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void ShopScreen()
    {
        SceneManager.LoadScene("Shop");
    }
    public void StatsScreen()
    {
        SceneManager.LoadScene("Stats");
    }
    public void SelectMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PauseScene()
    {
        Time.timeScale = 0;
    }
    public void UnPauseScene()
    {
        Time.timeScale = 1;
    }
}
