using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject ball = collider.gameObject;
        Destroy(ball);
    }
}
