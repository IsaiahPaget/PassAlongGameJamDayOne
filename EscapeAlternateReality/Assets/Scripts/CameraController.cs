using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _playerPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_playerPosition != null) {
            transform.position = new Vector3(_playerPosition.transform.position.x, _playerPosition.transform.position.y, _playerPosition.transform.position.z - 10); 
        }
    }
}
