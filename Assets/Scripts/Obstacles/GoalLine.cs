using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    public int ballCount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = collision.gameObject;
        CountBall(ball);
    }

    void CountBall(GameObject ball)
    {
        Destroy(ball);
        ballCount++;
    }
}
