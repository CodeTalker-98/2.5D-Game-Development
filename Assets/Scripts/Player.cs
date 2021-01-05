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
    private int _coins = 0;
    private int _lives = 3;
    private CharacterController _controller;
    private GameManager _gameManager;
    private UIManager _uiManager;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI MANAGER is NULL");
        }
        else
        {
            _uiManager.UpdateLivesText(_lives);
        }

        if (_gameManager == null)
        {
            Debug.LogError("The GAME MANAGER is NULL");
        }
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

    public void AddToCoins()
    {
        _coins++;
        _uiManager.UpdateCoinText(_coins);
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesText(_lives);

        if (_lives < 1)
        {
            _gameManager.RestartGame();
        }
    }
}
