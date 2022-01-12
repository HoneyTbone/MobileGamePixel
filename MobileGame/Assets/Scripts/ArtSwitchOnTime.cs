using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtSwitchOnTime : MonoBehaviour
{
    public float timeBeforeSwitch;
    private float time;
    public GameObject art1;
    public GameObject art2;
    private int checker = 1;
    public bool spinning;
    public bool switching;
    private int spinlocation;
    public Transform artTransform;
    private int randLocation;

    void Start()
    {
        time = timeBeforeSwitch;
        spinlocation = 0;
        randLocation = Random.Range(0, 2);
    }
    // Update is called once per frame
    void Update()
    {
        if(switching == true)
        {
            if (time <= 0)
            {
                if (checker == 1)
                {
                    art2.SetActive(true);
                    art1.SetActive(false);
                    time = timeBeforeSwitch;
                    checker = 0;
                }
                else if (checker == 0)
                {
                    art1.SetActive(true);
                    art2.SetActive(false);
                    time = timeBeforeSwitch;
                    checker = 1;
                }

            }
            else
            {
                time -= Time.deltaTime;
            }
        }

        if(spinning == true)
        {
            if (time <= 0)
            {
                if (randLocation == 0)
                {
                    spinlocation++;
                }
                if(randLocation == 1)
                {
                    spinlocation--;
                }
                
                artTransform.rotation = Quaternion.Euler(0, 0, spinlocation);
                time = timeBeforeSwitch;
                if (spinlocation > 359)
                {
                    spinlocation = 0;
                }
                else if (spinlocation < -359)
                {
                    spinlocation = 0;
                }
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
        
    }
}
