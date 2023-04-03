using System;
using UnityEngine;

namespace Ship.Data
{
    [CreateAssetMenu(fileName = "New Ship Movement Definition", menuName = "Whitespace/Ship/Ship Movement Definition", order = 1)]
    public class ShipMovementDefinition : ScriptableObject
    {
        public float Acceleration => _acceleration;
        public float MaxSpeed => _maxSpeed;
        public float BreakDragMultiplier => _brakeDragMultiplier;
        
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _brakeDragMultiplier;
    }
}