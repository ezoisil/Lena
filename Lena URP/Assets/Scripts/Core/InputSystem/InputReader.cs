using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Core.EventChannels
{

    [CreateAssetMenu(menuName = "Input /Input Reader")]
    public class InputReader : ScriptableObject, GameInputActions.IGameplayActions, GameInputActions.IUIActions
    {
        // Game Inputs
        public UnityAction<Vector2> MoveEvent = delegate { };
        public UnityAction MoveCancelledEvent = delegate { };
        public UnityAction DashEvent = delegate { };
        public UnityAction SprintEvent = delegate { };
        public UnityAction PrimaryAttackEvent = delegate { };

        private GameInputActions _gameInputActions;

        private void OnEnable()
        {
            if (_gameInputActions == null)
            {
                _gameInputActions = new GameInputActions();

                SetCallbacks();
            }
        }

        private void OnDisable()
        {
            DisableAllInput();
        }
        
        public void EnableAllInput()
        {
            _gameInputActions.Gameplay.Enable();
            _gameInputActions.UI.Enable();
        }

        public void EnableGameInput()
        {
            _gameInputActions.Gameplay.Enable();
            _gameInputActions.UI.Disable();
        }

        public void EnableUIInput()
        {
            _gameInputActions.Gameplay.Disable();
            _gameInputActions.UI.Enable();
        }

        public void DisableAllInput()
        {
            _gameInputActions.Gameplay.Disable();
            _gameInputActions.UI.Disable();
        }

        #region Input Event Listeners

        public void OnMovement(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
            if (context.phase == InputActionPhase.Canceled)
                MoveCancelledEvent?.Invoke();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                DashEvent?.Invoke();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                SprintEvent?.Invoke();
        }

        public void OnPrimaryAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                PrimaryAttackEvent?.Invoke();
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {

        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SetCallbacks()
        {
            _gameInputActions.Gameplay.SetCallbacks(this);
            _gameInputActions.UI.SetCallbacks(this);
        }

        #endregion
       

    }

}
