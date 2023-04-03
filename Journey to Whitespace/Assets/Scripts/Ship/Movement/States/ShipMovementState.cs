using MHR.StateMachine;

namespace Ship.Movement.States
{
    public abstract class ShipMovementState : State
    {
        protected ShipMovement ShipMovement;

        public void SetShipMovement(ShipMovement shipMovement)
        {
            ShipMovement = shipMovement;
        }
        
        public abstract override void EnterState();
        public abstract override void ExitState();
        public abstract override void ProcessState();
        public abstract override void ProcessStateFixed();
    }
}