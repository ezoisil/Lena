using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input_System
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 MovementVector { get; private set; }
        public int SprintMultiplier { get; private set; }
        
        private GameInputActions _gameInputActions; 
        private void Awake()
        {
            _gameInputActions = new GameInputActions();
            _gameInputActions.Gameplay.Enable();
            _gameInputActions.Gameplay.Dash.performed += OnDashPerformed;
            _gameInputActions.Gameplay.Sprint.started += OnSprintStarted;
        }

        private void Update()
        {
            MovementVector = _gameInputActions.Gameplay.Movement.ReadValue<Vector2>();
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
