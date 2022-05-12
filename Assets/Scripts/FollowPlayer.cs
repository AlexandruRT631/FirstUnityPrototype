using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _positionOffset;
    private Quaternion _rotation;
    private int _fpc = 0;

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
            _fpc = (_fpc + 1) % 3;
        }

        transform.position = player.transform.position;
        if (_fpc == 1)
        {
            transform.Translate(Vector3.up * 2 + Vector3.forward * 3);
            transform.rotation = player.transform.rotation;
        }
        else if (_fpc == 0)
        {
            transform.position += _positionOffset;
            transform.rotation = _rotation;
        }
        else
        {
            transform.position += Vector3.up * 100;
            transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.up);
        }
    }
}