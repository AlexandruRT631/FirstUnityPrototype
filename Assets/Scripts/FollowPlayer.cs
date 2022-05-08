using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _positionOffset;
    private Quaternion _rotation;
    private bool _fpc = false;

    // Start is called before the first frame update
    public void Start()
    {
        _positionOffset = transform.position - player.transform.position;
        _rotation = transform.rotation;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _fpc = !_fpc;
        }

        transform.position = player.transform.position;
        if (_fpc)
        {
            transform.Translate(Vector3.up * 2 + Vector3.forward * 3);
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position += _positionOffset;
            transform.rotation = _rotation;
        }
    }
}