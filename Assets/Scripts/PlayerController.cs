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
    public float fakeForwardInput = 1.0f;
    public float fakeHorizontalInput = 1.0f;
    public string horizAxis = "Horizontal";
    public string vertiAxis = "Vertical";

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        // _oldPos = transform.position;
    }

    public void Update()
    {
        // Getting player input
        horizontalInput = Input.GetAxis(horizAxis);
        forwardInput = Input.GetAxis(vertiAxis);
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
            fakeForwardInput = forwardInput;
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            // Turn the vehicle based on horizontal and forward input
            fakeHorizontalInput = horizontalInput;
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
        }
        else
        {
            if (fakeForwardInput < 0.01f && fakeForwardInput > -0.01f)
            {
                fakeForwardInput = 0f;
            }
            else
            {
                fakeForwardInput -= fakeForwardInput / Mathf.Abs(fakeForwardInput) * Time.deltaTime / speed;
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed * fakeForwardInput);
            
            if (fakeHorizontalInput < 0.01f && fakeHorizontalInput > -0.01f)
            {
                fakeHorizontalInput = 0f;
            }
            else
            {
                fakeHorizontalInput -= fakeHorizontalInput / Mathf.Abs(fakeHorizontalInput) * Time.deltaTime / speed;
            }
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * fakeHorizontalInput * fakeForwardInput);
        }
        // _oldPos = transform.position;
        // Turn the vehicle based on horizontal and forward input
        // transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
    }
}
