using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] InputAction _strafing;
    [SerializeField] InputAction _aim;
    [SerializeField] float _speed = 6f;
    [SerializeField] float _turnSmoothTime = 0.1f;
    [SerializeField] Transform cam;
    [SerializeField] GameObject thirdPersonCam;
    [SerializeField] GameObject lockOnCam;

    float _turnSmoothVelocity;
    CharacterController _controller;
    private Vector3 _direction;
    float _cameraAngle;
    bool _hasLockedOn;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _aim.performed += _ => ToggleCamera();
        _hasLockedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDirection = _strafing.ReadValue<Vector2>();
        _direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
    }

    void FixedUpdate()
    {
        if (_direction.magnitude >= 0.1)
        {
            Turn(ref _cameraAngle);
            Move(_cameraAngle, _speed);
        }

    }
    
    void Turn(ref float newCamAngle)
    {
        //Update camera angle for moving player
        newCamAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        //Turn to face camera (for player strafing with left and right movement)
        float turnAngle = cam.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turnAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
    }

    void Move(float facingAngle, float speed)
    {
        Vector3 movDir = Quaternion.Euler(0f, facingAngle, 0f) * Vector3.forward;

        _controller.Move(movDir.normalized * speed * Time.deltaTime);
    }

    void ToggleCamera()
    {
        //Update Look At Target

        thirdPersonCam.SetActive(_hasLockedOn);
        _hasLockedOn = !_hasLockedOn;
    }

    void OnEnable()
    {
        _strafing.Enable();
        _aim.Enable();
    }

    void OnDisable()
    {
        _strafing.Disable();
        _aim.Disable();
    }

}
