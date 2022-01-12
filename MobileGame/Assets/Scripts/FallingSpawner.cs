using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    public float maxTimeSpawn;
    public float minTimeSpawn;
    private float time;
    public GameObject fallingObject;
    private Vector3 objectPosition = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(minTimeSpawn, maxTimeSpawn);
    }

    // Update is called once per frame
    void Update()
    {

        if (time <= 0)
        {
            objectPosition.x = Random.Range(-3f, 3f);
            objectPosition.y = transform.position.y;
            Instantiate(fallingObject, objectPosition, Quaternion.identity);
            time = Random.Range(minTimeSpawn, maxTimeSpawn);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
