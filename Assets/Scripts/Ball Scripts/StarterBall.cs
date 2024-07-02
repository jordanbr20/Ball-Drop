using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StarterBall : MonoBehaviour
{
    bool ballDropped;
    GameObject starterBall;
    Rigidbody2D sbRigid;
    Transform sbPos;
    
    bool isDragged = false;
    Vector3 offset;
    float yPos;

    Camera cam;
    float minX, maxX;

    void Start()
    {
        BallManager.Instance.RegisterBall(transform);
        ballDropped = false;
        starterBall = this.gameObject;
        sbRigid = this.gameObject.GetComponent<Rigidbody2D>();

        sbRigid.gravityScale = 0f;
        yPos = transform.position.y;

        cam = Camera.main;

        float camDistance = Vector3.Distance(transform.position, cam.transform.position);
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0,0, camDistance));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1,0, camDistance));

        minX = bottomLeft.x + GetComponent<Renderer>().bounds.extents.x;
        maxX = topRight.x - GetComponent<Renderer>().bounds.extents.x;
    }

    void Update()
    {
        if(ballDropped)
        {
            BallDropped();
        }
    }

    private void OnMouseDown()
    {
        isDragged = true;
        if(!ballDropped)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePos;
            offset.z = 0f;
        }
    }

    private void OnMouseDrag()
    {
        if(isDragged)
        {
            //transform.localPosition = spriteDragStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPos);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float newX = Mathf.Clamp(mousePos.x + offset.x, minX, maxX);

            transform.position = new Vector3(newX, yPos, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        if(!ballDropped)
        {
            isDragged = false;
            ballDropped = true;
        }
    }

    private void BallDropped()
    {
        sbRigid.gravityScale = 1f;
    }

    void OnDestroy()
    {
        BallManager.Instance.UnregisterBall(transform);
    }
}
