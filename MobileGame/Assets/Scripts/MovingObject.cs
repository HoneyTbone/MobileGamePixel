using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private bool movingLeft;

    public Transform moveSpotLeft;
    public Transform moveSpotRight;
    private int randomSpot;
    public bool flips;
    public bool oneWay;
    private int randLeftOrRight;

    public bool screenWize;


    // Start is called before the first frame update
    void Start()
    {
        if(screenWize == false)
        {
            moveSpotLeft.position = new Vector3(-3.5f, transform.position.y, 0f);
            moveSpotRight.position = new Vector3(3.5f, transform.position.y, 0f);
            if (oneWay == true)
            {
                moveSpotLeft.position = new Vector3(-5f, transform.position.y, 0f);
                moveSpotRight.position = new Vector3(5f, transform.position.y, 0f);
            }
        } 
        movingLeft = true;
        waitTime = startWaitTime;
        randLeftOrRight = Random.Range(0, 2);
        if(randLeftOrRight == 1)
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(randLeftOrRight == 0)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flips == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (movingLeft == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpotLeft.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpotLeft.position) < 0.05f)
            {
                if (waitTime <= 0)
                {
                    waitTime = startWaitTime;
                    if(oneWay == false)
                    {
                        movingLeft = false;
                    }
                    if(oneWay == true)
                    {
                        transform.position = new Vector3(5f, transform.position.y, 0f);
                    }
                    
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        if (movingLeft == false)
        {
            if(flips == true)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, moveSpotRight.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpotRight.position) < 0.05f)
            {
                if (waitTime <= 0)
                {
                    waitTime = startWaitTime;
                    if (oneWay == false)
                    {
                        movingLeft = true;
                    }
                    if (oneWay == true)
                    {
                        transform.position = new Vector3(-5f, transform.position.y, 0f);
                    }   
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
            

    }
}
