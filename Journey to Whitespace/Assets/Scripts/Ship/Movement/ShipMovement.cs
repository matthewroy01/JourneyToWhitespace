using System;
using UnityEngine;
using MHR.StateMachine;
using MHRUtil.Interfaces;
using Ship.Data;
using Ship.Movement.States;

namespace Ship.Movement
{
    [RequireComponent(typeof(ShipMovementDefaultState))]
    public class ShipMovement : MonoBehaviour, IUpdatable
    {
        public Rigidbody2D RB => _rb;
        public ShipMovementDefinition ShipMovementDefinition => _shipMovementDefinition;
        public float InitialDrag => _initialDrag;

        [SerializeField] private Rigidbody2D _rb;
        private StateMachine _stateMachine;
        [SerializeField] private ShipMovementDefaultState _defaultState;
        private ShipMovementDefinition _shipMovementDefinition;
        private float _initialDrag;

        public void Initialize(ShipMovementDefinition shipMovementDefinition)
        {
            _stateMachine = new StateMachine(_defaultState);
            _defaultState.SetShipMovement(this);

            _shipMovementDefinition = shipMovementDefinition;

            _initialDrag = _rb.drag;
        }

        public void MyUpdate()
        {
            _stateMachine.CurrentState.ProcessState();
        }

        public void MyFixedUpdate()
        {
            _stateMachine.CurrentState.ProcessStateFixed();
        }
    }
}