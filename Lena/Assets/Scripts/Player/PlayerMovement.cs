using System;
using System.Collections;
using System.Collections.Generic;
using Core.EventChannels;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private Rigidbody _rigidbody;

    [NonSerialized] public Vector3 MovementInput;
    [NonSerialized] public Vector3 MovementVector;
    [NonSerialized] public bool DashInput;
    [NonSerialized] public bool SprintInput;

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
        _mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        CalculateMovementVector();
    }

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
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
        MovementInput = dislocation;
        _rigidbody.velocity = dislocation;
    }

    private void OnDash()
    {
        
    }

    #endregion

    private void CalculateMovementVector()
    {
        _cameraForward = _mainCameraTransform.forward;
        _cameraRight = _mainCameraTransform.right;

        _cameraForward.y = 0;
        _cameraRight.y = 0;

        _adjustedMovement = _cameraRight.normalized * MovementInput.x + _cameraForward.normalized * MovementInput.y;

        if (MovementInput.sqrMagnitude == 0f)
        {
            _adjustedMovement = transform.forward * (_adjustedMovement.magnitude + .01f);
        }
    }
}
