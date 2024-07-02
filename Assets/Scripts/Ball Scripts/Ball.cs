using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer sr;
    public List<Color> colorsList = new List<Color>();
    public List<GameObject> doubledBy;
    
    AudioSource ballbounce;

    // Start is called before the first frame update
    void Start()
    {
        BallManager.Instance.RegisterBall(transform);
        ballbounce = this.gameObject.GetComponent<AudioSource>();
        colorsList.Add(Color.white);
        colorsList.Add(Color.red);
        colorsList.Add(Color.green);
        colorsList.Add(Color.black);
        colorsList.Add(Color.blue);
        colorsList.Add(Color.yellow);

        sr = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, colorsList.Count);
        sr.material.color = colorsList[rand];     

        if(this.gameObject.name != "StarterBall")
        {
            this.transform.position = new Vector3(this.transform.position.x + Random.Range(.1f,.2f), this.transform.position.y, this.transform.position.z);
        }   
    }

    public void CopyOldDouble(List<GameObject> oldDoublerList)
    {
        doubledBy = oldDoublerList;
    }

    public void AddDouble(GameObject doubler)
    {
        doubledBy.Add(doubler);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        GameObject BallHit = collisionInfo.gameObject;

        if(BallHit.tag == "Obstacle")
        {
            ballbounce.Play();
        }
    }

    void OnDestroy()
    {
        BallManager.Instance.UnregisterBall(transform);
    }
}
