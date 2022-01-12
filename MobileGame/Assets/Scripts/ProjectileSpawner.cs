using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform objectLocation;
    public GameObject Projectile;

    private float randTime;
    public float minSpawnTime;
    public float maxSpawnTime;

    void Update()
    {
        if(randTime <= 0)
        {
            Instantiate(Projectile, objectLocation.position, Quaternion.identity); // spawns object
            randTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
        else
        {
            randTime -= Time.deltaTime;
        }
        
    }
}
