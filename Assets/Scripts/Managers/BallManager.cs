using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance { get; private set; }

    private List<Transform> balls = new List<Transform>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterBall(Transform ball)
    {
        balls.Add(ball);
    }

    public void UnregisterBall(Transform ball)
    {
        balls.Remove(ball);
    }

    public Transform GetLowestBall()
    {
        if (balls.Count == 0) return null;

        Transform lowestBall = balls[0];
        foreach (Transform ball in balls)
        {
            if (ball.position.y < lowestBall.position.y)
            {
                lowestBall = ball;
            }
        }
        return lowestBall;
    }
}
