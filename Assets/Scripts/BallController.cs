using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float jumpForce = 5.0f;
    public float jumpDelay = 1.0f;
    private float lastJump = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.time > lastJump + jumpDelay)
        {
            lastJump = Time.time;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
