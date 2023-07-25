using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _maxSpeed;
    float _currentSpeed;

    [SerializeField]
    float _turnSpeed;
    Vector2 _movement;
    Rigidbody2D _rb;

    void Awake()
    {  
        _rb = GetComponent<Rigidbody2D>();
        _currentSpeed = _maxSpeed;
    }

    void FixedUpdate()
    {
        RotatePlayer(_movement.x);
        MovePlayer(_movement.y);
    }

    void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    void RotatePlayer(float direction)
    {
        // Calculate the rotation amount based on the direction and rotation speed
        float rotationAmount = -direction * _turnSpeed * Time.deltaTime;

        // Apply the rotation to the player object
        transform.Rotate(0f, 0f, rotationAmount);
    }

    void MovePlayer(float direction)
    {
        // Calculate the force vector based on the direction of movement
        Vector2 forceVector = transform.up * direction * _currentSpeed * Time.deltaTime;

        // Apply the force to the player object
        _rb.velocity = forceVector;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Grass") {
            _currentSpeed = _maxSpeed * 0.69f; // :)
        }
        if (collider.tag == "DeathWall") {
            Debug.Log("You Died!");
            Destroy(gameObject);
        }
        if (collider.tag == "Portal") {
            Debug.Log("You Did It!");
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Grass") {
            _currentSpeed = _maxSpeed;
        }
    }

}
