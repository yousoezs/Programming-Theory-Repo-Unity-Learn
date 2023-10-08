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

    private bool _isRunning;
    private bool _isJumping;

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
    }

    private void Update()
    {
        Move();
    }

    //POLYMORPHISM
    public override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            _direction = new Vector3(0, 0, verticalInput * WalkSpeed);
            _playerControl.Move(_direction * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction = new Vector3(0, 0, --verticalInput * WalkSpeed);
            _playerControl.Move(_direction * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction = new Vector3(--horizontalInput * WalkSpeed, 0, 0);
            _playerControl.Move(_direction * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction = new Vector3(horizontalInput * WalkSpeed, 0, 0);
            _playerControl.Move(_direction * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            WalkSpeed = _runSpeed;
    }
    //POLYMORPHISM
    public override void Jump()
    {
        
    }
    //POLYMORPHISM
    public override void Talk()
    {
        
    }
}
