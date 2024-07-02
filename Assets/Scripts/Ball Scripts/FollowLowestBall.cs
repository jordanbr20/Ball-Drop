using UnityEngine;

public class FollowLowestBall : MonoBehaviour
{
    private BallManager ballManager;
    private float initialOrthographicSize;
    public float threshold = 1.0f;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        ballManager = BallManager.Instance;
        if (Camera.main.orthographic)
        {
            initialOrthographicSize = Camera.main.orthographicSize;
        }
    }

    void Update()
    {
        Transform lowestBall = ballManager.GetLowestBall();
        if (lowestBall != null)
        {
            // Get the world position of the bottom of the camera view
            float cameraBottomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;

            // Move the camera only if the lowest ball is within the threshold distance to the bottom
            if (lowestBall.position.y <= cameraBottomY + threshold)
            {
                // Keep the camera's X and Z positions constant
                Vector3 targetPosition = new Vector3(transform.position.x, lowestBall.position.y, transform.position.z);

                // Smoothly move the camera towards the target position
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

                // Maintain the initial orthographic size if the camera is orthographic
                if (Camera.main.orthographic)
                {
                    Camera.main.orthographicSize = initialOrthographicSize;
                }
            }
        }
    }
}
