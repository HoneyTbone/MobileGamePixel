using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESETPREFS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
