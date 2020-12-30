using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpHeight = 15.0f;
    [SerializeField] private float _spd;
    private bool _canDoubleJump = false;
    private float _yVelocity;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _spd;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
