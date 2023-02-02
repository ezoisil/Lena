using System;
using System.Collections;
using System.Collections.Generic;
using Core.EventChannels;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private Rigidbody _rigidbody;

    [NonSerialized] public Vector3 MovementVector;
    [NonSerialized] public bool DashInput;
    [NonSerialized] public bool IsSprinting;

    private int _slowDownBuffer = 0;
    private Vector3 _movementInput;
    private bool _isMoving;

    #region Movement Vector Calculation Specific Variables

    private float _targetSpeed;
    private Vector3 _adjustedMovement;
    private Vector3 _cameraForward;
    private Vector3 _cameraRight;
    private float _previousSpeed;
    private Transform _mainCameraTransform;

    #endregion

    private void Start()
    {
        if (Camera.main != null)
            _mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        CalculateMovementVector();
        if(_isMoving)
            Move();
    }

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
        _inputReader.DashEvent += OnDash;
        _inputReader.EnableGameInput();
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }

    #region Event Listeners

    private void OnMove(Vector2 dislocation)
    {
        Debug.Log(dislocation);
        _movementInput = dislocation;
        _rigidbody.velocity = dislocation;
    }

    private void OnDash()
    {
        DashInput = true;
    }

    #endregion
    private void CalculateMovementVector()
    {
        _cameraForward = _mainCameraTransform.forward;
        _cameraRight = _mainCameraTransform.right;

        _cameraForward.y = 0;
        _cameraRight.y = 0;

        _adjustedMovement = _cameraRight.normalized * _movementInput.x + _cameraForward.normalized * _movementInput.y;

        if (_movementInput.sqrMagnitude == 0f)
        {
            _adjustedMovement = transform.forward * (_adjustedMovement.magnitude + .01f);
            _isMoving = false;
        }
        
        _targetSpeed = Mathf.Clamp01(_movementInput.magnitude);
        if (_targetSpeed > 0f)
        {
            _isMoving = true;
            if (IsSprinting)
                _targetSpeed = 1f;

            if (_slowDownBuffer > 0)
                _targetSpeed = .05f;
        }
        _targetSpeed = Mathf.Lerp(_previousSpeed, _targetSpeed, Time.deltaTime * 4f);

        MovementVector = _adjustedMovement.normalized * _targetSpeed;

        _previousSpeed = _targetSpeed;
    }

    private void Move()
    {
        _rigidbody.velocity = MovementVector;
    }
}
