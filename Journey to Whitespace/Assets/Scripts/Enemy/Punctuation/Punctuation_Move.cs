using Steering;
using UnityEngine;

namespace Enemy.Punctuation
{
    public class Punctuation_Move : EnemyState
    {
        [SerializeField] private SteeringController _steeringController;

        public override void EnterState() { }
        public override void ExitState() { }
        public override void ProcessState() { }
        
        public override void ProcessStateFixed()
        {
            _steeringController.Steer();
        }
    }
}
