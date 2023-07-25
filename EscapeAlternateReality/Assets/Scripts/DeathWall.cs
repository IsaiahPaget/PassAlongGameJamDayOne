using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    [SerializeField]
    float _speed;

    [SerializeField]
    GameObject _target;
    Rigidbody2D _rb;

    void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_target != null) {
            Vector3 moveDirection = _target.transform.position - transform.position;
            moveDirection.Normalize();
            _rb.velocity = (moveDirection * _speed * Time.deltaTime);
        } else {
            _rb.velocity = new Vector2(0,0);
        }
    }
}
