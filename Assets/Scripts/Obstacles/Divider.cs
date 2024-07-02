using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    public GameObject BallPre;
    public List<GameObject> Balls;
    Transform FirstBall;
    Transform oldBallTrans;
    List<GameObject> oldBallDoubler;
    public GameObject DoublerObj;
    public int ballCount = 0;

    void Start()
    {
        DoublerObj = this.gameObject;
        ballCount = 0;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = collision.gameObject;
        ball.GetComponent<Ball>().AddDouble(DoublerObj);
        ballCount++;
        if(ballCount == 2)
        {
            Destroy(ball);
            ballCount = 0;
        }
    }
}
