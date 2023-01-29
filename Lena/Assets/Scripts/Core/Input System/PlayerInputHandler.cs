using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input_System
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementVector { get; private set; }
        public int SprintMultiplier { get; private set; }
        
        private PlayerInputActions _playerInputActions; 
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Dash.performed += OnDashPerformed;
            _playerInputActions.Player.Sprint.started += OnSprintStarted;
        }

        private void Update()
        {
            MovementVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        }

        #region EventListeners

        private void OnDashPerformed(InputAction.CallbackContext callbackContext)
        {
        }  
        private void OnSprintStarted(InputAction.CallbackContext callbackContext)
        {
            SprintMultiplier = SprintMultiplier == 1 ? 0 : 1;
        }

        #endregion
    }

}
