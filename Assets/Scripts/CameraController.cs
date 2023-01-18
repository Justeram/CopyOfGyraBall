using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float turnSpeed = 2.0f;

    private float horizontalInput;

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }
        offset = Quaternion.AngleAxis(horizontalInput * turnSpeed, Vector3.up) * offset;
        Vector3 desiredPosition = ball.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(ball.transform);
    }
}