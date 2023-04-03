using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Management
{
    public class InputManager : MonoBehaviour, Controls.IDefaultActions
    {
        public static event Action<float> HorizontalAxisUpdated;
        public static event Action<float> VerticalAxisUpdated;
        public static Vector2 MousePosition => _mousePosition;
        public static event Action LeftClickPerformed;
        public static event Action RightClickPerformed;
        public static event Action ShiftEntered;
        public static event Action ShiftCanceled;
        public static event Action CapsLockPerformed;

        private Controls _controls;
        private static Vector2 _mousePosition;

        private void Awake()
        {
            _controls = new Controls();
            _controls.Default.SetCallbacks(this);
            _controls.Enable();
        }

        public void OnVerticalAxis(InputAction.CallbackContext context)
        {
            VerticalAxisUpdated?.Invoke(context.ReadValue<float>());
        }

        public void OnHorizontalAxis(InputAction.CallbackContext context)
        {
            HorizontalAxisUpdated?.Invoke(context.ReadValue<float>());
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            _mousePosition = context.ReadValue<Vector2>();
        }

        public void OnPrimaryFire(InputAction.CallbackContext context)
        {
            if (!GetContextTypeMet(context, InputContextType.Started))
                return;
            
            LeftClickPerformed?.Invoke();
        }

        public void OnSecondaryFire(InputAction.CallbackContext context)
        {
            if (!GetContextTypeMet(context, InputContextType.Started))
                return;
            
            RightClickPerformed?.Invoke();
        }

        public void OnShift(InputAction.CallbackContext context)
        {
            if (GetContextTypeMet(context, InputContextType.Started))
                ShiftEntered?.Invoke();
            
            if (GetContextTypeMet(context, InputContextType.Canceled))
                ShiftCanceled?.Invoke();
        }

        public void OnCapsLock(InputAction.CallbackContext context)
        {
            if (!GetContextTypeMet(context, InputContextType.Started))
                return;
            
            CapsLockPerformed?.Invoke();
        }

        private bool GetContextTypeMet(InputAction.CallbackContext context, InputContextType inputContextType)
        {
            return inputContextType switch
            {
                InputContextType.All => true,
                InputContextType.Started => context.started,
                InputContextType.Performed => context.performed,
                InputContextType.Canceled => context.canceled,
                InputContextType.StartedOrPerformed => context.started || context.performed,
                InputContextType.StartedOrCanceled => context.started || context.canceled,
                InputContextType.PerformedOrCanceled => context.performed || context.canceled,
                _ => false
            };
        }
    }
}