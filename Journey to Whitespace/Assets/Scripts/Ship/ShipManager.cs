using Ship.Data;
using Ship.Movement;
using UnityEngine;

namespace Ship
{
    public class ShipManager : MonoBehaviour
    {
        public ShipDefinition ShipDefinition => _shipDefinition;
        
        [SerializeField] private ShipDefinition _shipDefinition;
        [SerializeField] private ShipMovement _shipMovement;

        private void Awake()
        {
            _shipMovement.Initialize(_shipDefinition.Movement);
        }
    }
}
