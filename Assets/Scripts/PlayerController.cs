using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;
    public float horizontalInput;
    public float forwardInput;
    // public float distToGround = 1.0f;
    // public bool grounded = false;
    public Rigidbody rb;
    // public Vector3 movement;
    // private Vector3 _oldPos;
    // public float currentVerticalSpeed = 0.0f;
    public float maxVerticalSpeed = 0.1f;
    public float fakeInput = 1.0f;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        // _oldPos = transform.position;
    }

    public void Update()
    {
        // Getting player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // transform.rotation.y returns values from -1 to 1 instead of -180 to 180
        // var angle = transform.eulerAngles.y * Mathf.Deg2Rad;
        // movement = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * forwardInput;
    }

// Update is called once per frame
    public void FixedUpdate()
    {
        // currentVerticalSpeed = Mathf.Abs(_oldPos.y - transform.position.y) * Time.deltaTime;
        // _oldPos = transform.position;
        
        // Move the vehicle forward
        // rb.AddForce(movement * Time.deltaTime * speed);
        if (Mathf.Abs(rb.velocity.y) < maxVerticalSpeed)
        {
            fakeInput = forwardInput;
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }
        else
        {
            if (fakeInput < 0.01f && fakeInput > -0.01f)
            {
                fakeInput = 0f;
            }
            else
            {
                fakeInput -= fakeInput / Mathf.Abs(fakeInput) * Time.deltaTime / speed;
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed * fakeInput);
        }
        // _oldPos = transform.position;
        // Turn the vehicle based on horizontal and forward input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
    }
}
