using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal // INHERITANCE
{
    #region Fields
    private string _catName = "Ragdoll";
    
    private int _catAge = 5;

    private float _runSpeed = 2f;
    private float _jumpForce = 1500f;
    private float _gravity = 1000f;
    
    private Vector3 _direction;

    private CharacterController _playerControl;
    #endregion
    private void Awake()
    {
        Name = _catName;
        Age = _catAge;

        _runSpeed *= WalkSpeed;

        _playerControl = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Debug.Log($"Cat Name: {GetName(Name)}");
        Debug.Log($"Cat Age: {GetAge(Age)}");
        Debug.Log($"Switchin to PlayerName and Age");
    }

    private void Update()
    {
        PlayerControls();
    }

    //ENCAPSULATION
    private void PlayerControls()
    {
        Move();
        Jump();
        Talk();
        ApplyGravity();

        _playerControl.Move(_direction * Time.deltaTime);
        _direction = Vector3.zero;
    }
    private void ApplyGravity()
    {
        if (_playerControl.isGrounded) return;
        _direction.y -= _gravity * Time.deltaTime;
    }

    //POLYMORPHISM
    public override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            _direction = new Vector3(0, 0, verticalInput * WalkSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction = new Vector3(0, 0, --verticalInput * WalkSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction = new Vector3(--horizontalInput * WalkSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction = new Vector3(horizontalInput * WalkSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            WalkSpeed = _runSpeed;
    }
    //POLYMORPHISM
    public override void Jump()
    {
        if (!_playerControl.isGrounded) return;
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log($"Jumping");
            _direction.y += _jumpForce;
        }
    }
    //POLYMORPHISM
    public override void Talk()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"Meooooow!");
        }
    }
}
