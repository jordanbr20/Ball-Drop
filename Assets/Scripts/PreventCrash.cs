using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventCrash : MonoBehaviour
{
    public int allBalls;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        allBalls = GameObject.FindGameObjectsWithTag("Ball").Length;

        if(allBalls > 5000)
        {
            Time.timeScale = 0;
        }
    }
}
