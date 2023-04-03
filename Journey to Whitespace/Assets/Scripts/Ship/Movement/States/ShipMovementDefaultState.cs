using Management;
using UnityEngine;

namespace Ship.Movement.States
{
    public class ShipMovementDefaultState : ShipMovementState
    {
        private float _horizontalAxis;
        private float _verticalAxis;
        
        public override void EnterState()
        {
            InputManager.HorizontalAxisUpdated += OnHorizontalAxisUpdated;
            InputManager.VerticalAxisUpdated += OnVerticalAxisUpdated;
        }

        public override void ExitState()
        {
            InputManager.HorizontalAxisUpdated -= OnHorizontalAxisUpdated;
            InputManager.VerticalAxisUpdated -= OnVerticalAxisUpdated;
        }

        public override void ProcessState() { }

        public override void ProcessStateFixed()
        {
            SetDrag();
            Accelerate();
            TerminalVelocity();
        }

        private void Accelerate()
        {
            Vector2 direction = new Vector2(_horizontalAxis, _verticalAxis).normalized;
            direction *= ShipMovement.ShipMovementDefinition.Acceleration;
            
            ShipMovement.RB.AddForce(direction);
        }

        private void TerminalVelocity()
        {
            float maxSpeed = ShipMovement.ShipMovementDefinition.MaxSpeed;
            
            if (ShipMovement.RB.velocity.magnitude > maxSpeed)
            {
                ShipMovement.RB.velocity = ShipMovement.RB.velocity.normalized * maxSpeed;
            }
        }

        private void OnHorizontalAxisUpdated(float value)
        {
            _horizontalAxis = value;
        }

        private void OnVerticalAxisUpdated(float value)
        {
            _verticalAxis = value;
        }

        private void SetDrag()
        {
            bool noInput = Mathf.Abs(_horizontalAxis) < 0.1f && Mathf.Abs(_verticalAxis) < 0.1f;
            float noInputDrag = ShipMovement.InitialDrag * ShipMovement.ShipMovementDefinition.BreakDragMultiplier;
            ShipMovement.RB.drag = noInput ? noInputDrag : ShipMovement.InitialDrag;
        }
    }
}