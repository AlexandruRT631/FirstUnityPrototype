using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private readonly Vector3 _offset = new Vector3(25.0f, 0.0f, 10.0f);

    // Start is called before the first frame update
    public void Start()
    {
        transform.rotation.Set(0.0f, 270.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = plane.transform.position + _offset;
    }
}
