using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.AngryFace
{
    public class AngryFace_MoveTowardsPointAroundPlayer : EnemyState
    {
        public event Action ReachedTargetPosition;
        
        [SerializeField] private float _distanceFromPlayer;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _speed;
        [SerializeField] private float _distanceToTargetPosition;
        private Vector2 _targetPosition;
        
        public override void EnterState()
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            _targetPosition = (Vector2)Enemy.PlayerTransform.position + (randomDirection.normalized * _distanceFromPlayer);
        }

        public override void ExitState() { }

        public override void ProcessState()
        {
            if (Vector2.SqrMagnitude(_targetPosition - (Vector2)transform.position) <
                _distanceToTargetPosition * _distanceToTargetPosition)
            {
                ReachedTargetPosition?.Invoke();
            }
        }

        public override void ProcessStateFixed()
        {
            if (Enemy.RB.velocity.magnitude > _speed)
                return;
            
            Enemy.RB.AddForce((_targetPosition - (Vector2)transform.position).normalized * _acceleration);
        }
    }
}