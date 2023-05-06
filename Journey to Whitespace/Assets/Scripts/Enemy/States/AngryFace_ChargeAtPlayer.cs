using System;
using AudioManagement.SFX;
using UnityEngine;

namespace Enemy.States
{
    public class AngryFace_ChargeAtPlayer : EnemyState
    {
        public event Action DoneCharging;
        
        [SerializeField] private float _windupDuration;
        [SerializeField] private float _chargeDuration;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _particleSystem;
        private float _timer;
        private bool _charging = false;
        private Vector2 _targetDirection;
        
        public override void EnterState()
        {
            _charging = false;
            _timer = 0.0f;
            Enemy.RB.drag = 5.0f;
        }

        public override void ExitState()
        {
            _particleSystem.Stop();
        }

        public override void ProcessState()
        {
            if (_charging)
            {
                if (_timer < _chargeDuration)
                {
                    _timer += Time.deltaTime;
                    return;
                }
                
                DoneCharging?.Invoke();
            }
            else
            {
                if (_timer < _windupDuration)
                {
                    _timer += Time.deltaTime;
                    return;
                }
                
                _charging = true;
                Enemy.RB.drag = 1.0f;
                _targetDirection = (Enemy.PlayerTransform.position - transform.position).normalized;
                _timer = 0.0f;
                
                _particleSystem.transform.up = _targetDirection;
                _particleSystem.Play();
                
                SFXManager.Instance.QueueSound("Charge");
            }
        }

        public override void ProcessStateFixed()
        {
            if (!_charging)
                return;
            
            if (Enemy.RB.velocity.magnitude > _speed)
                return;
            
            Enemy.RB.AddForce(_targetDirection * _acceleration);
        }
    }
}