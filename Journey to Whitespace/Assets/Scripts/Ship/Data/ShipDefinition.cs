using UnityEngine;

namespace Ship.Data
{
    [CreateAssetMenu(fileName = "New Ship Definition", menuName = "Whitespace/Ship/Ship Definition", order = 1)]
    public class ShipDefinition : ScriptableObject
    {
        public string ShipName => _shipName;
        public ShipMovementDefinition Movement => _movement;
        
        [SerializeField] private string _shipName;
        [SerializeField] private ShipMovementDefinition _movement;
    }
}