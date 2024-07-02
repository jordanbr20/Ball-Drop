using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenuBallSpawner : MonoBehaviour
{
    public bool paused;
    public GameObject BallPre;
    public List<GameObject> aliveBalls;
    public int maxBalls;
    public float speed = 0.2f;
    bool isCoroutineRunning;

    void Start()
    {
        
        StartCoroutine(SpawnBalls());
    }

    void Update()
    {
        if(aliveBalls.Count > 100)
        {
            Time.timeScale = 0;
        }

        for(var i = aliveBalls.Count - 1; i >= 0; i--)
        {
            if(aliveBalls[i] == null)
            {
                aliveBalls.RemoveAt(i);
            }
        }

        if(!isCoroutineRunning)
        {
            Restart();
        }
    }

    void Restart()
    {
        Destroy(aliveBalls[0]);
        Destroy(aliveBalls[1]);
        Destroy(aliveBalls[2]);
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while(aliveBalls.Count < maxBalls)
        {
            isCoroutineRunning = true;
            Vector3 spawnpos = new Vector3(Random.Range(-20f,20f),10.5f);
            GameObject ball = (GameObject)Instantiate(BallPre, spawnpos, this.transform.rotation);
            aliveBalls.Add(ball);
            yield return new WaitForSeconds(speed);
        }
        isCoroutineRunning = false;
    }
}
