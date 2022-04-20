using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;
    
    // Start is called before the first frame update
    public void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
