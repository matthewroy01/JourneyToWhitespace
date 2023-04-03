using System;
using Ship.Data;
using Ship.Movement;
using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(ShipMovement), typeof(ShipCapitalization))]
    public class ShipManager : MonoBehaviour
    {
        public ShipDefinition ShipDefinition => _shipDefinition;
        
        [SerializeField] private ShipDefinition _shipDefinition;
        [SerializeField] private ShipMovement _shipMovement;
        [SerializeField] private ShipCapitalization _shipCapitalization;

        private void Awake()
        {
            _shipMovement.Initialize(_shipDefinition.Movement);
        }

        private void Update()
        {
            _shipMovement.MyUpdate();
            _shipCapitalization.MyUpdate();
        }

        private void FixedUpdate()
        {
            _shipMovement.MyFixedUpdate();
        }
    }
}