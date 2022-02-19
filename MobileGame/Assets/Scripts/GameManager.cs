using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* The code that spawns the platforms within the level
 * spawns a certian amount then when the player is high enough
 * it will spawn more. 
 * Selects random platform to spawn and spawns it differently each time */

public class GameManager : MonoBehaviour
{
    public GameObject[] platformPrefab; //Reference to all the platforms that could spawn in the level

    int prefeb_num; // is a random number within the array to add random platforms to the level

    public Transform player; // Reference to the Transform of the player

    public int platformCount = 0; // Number of platforms that the Method spawns before stopping
    private int spawnHeightChecker = 0; // If the player is higher than this y axis position it will spawn more platforms and increase the position
    private Vector3 spawnPosition = new Vector3(); // Where the platforms will be spawned

    public float minY = .5f; // lowest height difference for platforms
    public float maxY = 1.5f; // Highest height difference for platforms
    public int numberOfPlatformTypes; // How many platforms are in the platformPrefab Array

    public int chanceForStars; //Probality of star spawn chance
    private int starSpawnCheck; //Random number to select if stars spawn
    public GameObject star; // Reference to star prefab
    private Vector3 starPosition = new Vector3(); // Star Spawn location

    public int chanceForHearts; //Probality of heart spawn chance
    private int heartSpawnCheck; //Random number to select if hearts spawn
    public GameObject heart; // Reference to heart prefab
    private Vector3 heartPosition = new Vector3(); // Heart Spawn location

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // disallows screen dimming
        spawnHeightChecker = platformCount - 150; //Sets the position of the checker based on the number of platforms spawned
       // Debug.Log(spawnPosition);
        spawnNewPlatforms(spawnPosition); // calls the function using the spawn position Vector3
       // Debug.Log(spawnPosition);
        Time.timeScale = 0; // Keeps the game paused until the screen is tapped
        
    }
    void Update() // Called each frame
    {
        if(player.position.y >= spawnHeightChecker) // If the player is higher than the checker it spawns more platforms
        {
            spawnNewPlatforms(spawnPosition);
            spawnHeightChecker = spawnHeightChecker + platformCount;
        }
    }


    Vector3 spawnNewPlatforms(Vector3 newSpawnPosition)
    {
        //Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++) // for each platform being spawned
        {
            if(newSpawnPosition.y >= 15f) // No complex platforms for the first 15 meters
            {
                prefeb_num = Random.Range(0, numberOfPlatformTypes); // selects a random platformType
                starSpawnCheck = Random.Range(0, chanceForStars); // selects a random number for chanceForStars
                heartSpawnCheck = Random.Range(0, chanceForHearts); // selects a random number for chanceForHearts
            }
            else
            {
                prefeb_num = Random.Range(0, 2);
            }       
            newSpawnPosition.y += Random.Range(minY, maxY); // The Height Difference of where it could spawn
            newSpawnPosition.x = Random.Range(-3f, 3f); // The width of where it could spawn
            Instantiate(platformPrefab[prefeb_num], newSpawnPosition, Quaternion.identity); //Spawns the platform
            if(starSpawnCheck == chanceForStars - 1f) //Chance to spawn stars
            {
                starPosition.x = Random.Range(-3f, 3f);
                starPosition.y = newSpawnPosition.y + 0.5f; 
                // Sets star Spawn Location
                Instantiate(star, starPosition, Quaternion.identity); // spawns stars
            }
            if(heartSpawnCheck == chanceForHearts - 1f)
            {
                heartPosition.x = Random.Range(-3f, 3f);
                heartPosition.y = newSpawnPosition.y + 0.5f;
                // Sets heart Spawn Location
                Instantiate(heart, heartPosition, Quaternion.identity); // Spawns Hearts
            }
        }
        //Debug.Log("is" + newSpawnPosition);
        spawnPosition = newSpawnPosition; // Sets the spawnPosition to the New Spawn as reference for later spawns
        return newSpawnPosition; // Here so I dont get errors :) I am a great programmer
        
    }
}
