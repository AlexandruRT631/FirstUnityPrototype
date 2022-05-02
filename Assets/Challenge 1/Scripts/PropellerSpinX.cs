using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpinX : MonoBehaviour
{
    private const float Speed = 20.0f;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Speed);  
    }
}
