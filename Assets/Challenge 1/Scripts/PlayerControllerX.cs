using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private const float Speed = 15.0f;
    private const float RotationSpeed = 50.0f;
    private float _verticalInput;

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        // get the user's vertical input
        _verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime));

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * (RotationSpeed * Time.deltaTime * (-_verticalInput)));
    }
}