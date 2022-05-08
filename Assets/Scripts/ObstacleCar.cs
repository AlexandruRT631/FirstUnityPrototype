using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCar : MonoBehaviour
{
    public float speed = 20.0f;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
