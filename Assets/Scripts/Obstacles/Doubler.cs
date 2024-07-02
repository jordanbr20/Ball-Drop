using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doubler : MonoBehaviour
{
    public GameObject ballObj;
    GameObject oldball;
    Transform oldBallTrans;
    List<GameObject> oldBallDoubler;

    public GameObject DoublerObj;
    public int doubleAmount;
    int curamount = 1;

    void Start()
    {
        DoublerObj = this.gameObject;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        oldball = collision.gameObject;
        oldBallTrans = oldball.transform;
        oldBallDoubler = oldball.GetComponent<Ball>().doubledBy;

        if(oldBallDoubler.Contains(this.gameObject))
        {
            return;
        }

        Destroy(oldball);
        SpawnBall();
    }

    void SpawnBall()
    {
        curamount = 1;
        GameObject ball = (GameObject)Instantiate(ballObj, oldBallTrans.position, oldBallTrans.rotation);
        ball.gameObject.GetComponent<Ball>().doubledBy = oldBallDoubler;
        ball.gameObject.GetComponent<Ball>().AddDouble(DoublerObj);

        while(curamount < doubleAmount)
        {    
            Instantiate(ball);
            curamount++;
        }
    }
}
