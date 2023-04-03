using Management;
using MHRUtil.Interfaces;
using UnityEngine;

namespace Ship
{
    public class ShipCapitalization : MonoBehaviour, IUpdatable
    {
        [SerializeField] private Transform _lowercase;
        [SerializeField] private Transform _uppercase;
        private bool _capitalized;
        private bool _shiftHeld;
        private bool _capsLocked;

        private void OnEnable()
        {
            InputManager.ShiftEntered += OnShiftEntered;
            InputManager.ShiftCanceled += OnShiftCanceled;
            InputManager.CapsLockPerformed += OnCapsLockPerformed;
        }

        private void OnDisable()
        {
            InputManager.ShiftEntered -= OnShiftEntered;
            InputManager.ShiftCanceled -= OnShiftCanceled;
            InputManager.CapsLockPerformed -= OnCapsLockPerformed;
        }

        private void OnShiftEntered()
        {
            _shiftHeld = true;
        }

        private void OnShiftCanceled()
        {
            _shiftHeld = false;
        }

        private void OnCapsLockPerformed()
        {
            _capsLocked = !_capsLocked;
        }

        public void MyUpdate()
        {
            Capitalize();
        }

        public void MyFixedUpdate() { }

        private void Capitalize()
        {
            bool previousValue = _capitalized;
            
            _capitalized = _shiftHeld || _capsLocked;

            if (previousValue != _capitalized)
            {
                UpdateVisuals();
            }
        }

        private void UpdateVisuals()
        {
            _lowercase.gameObject.SetActive(!_capitalized);
            _uppercase.gameObject.SetActive(_capitalized);
        }
    }
}