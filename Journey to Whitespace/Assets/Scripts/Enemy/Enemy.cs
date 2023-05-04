using AudioManagement.SFX;
using HealthAndDamage;
using MHR.StateMachine;
using MHRUtil.DOTween.Transform;
using Ship;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public Rigidbody2D RB => _rb;
        public Transform PlayerTransform => _playerTransform;
        
        [SerializeField] private HealthEntity _healthEntity;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private PunchPositionTweenHelper _takeDamagePunchPositionTween;
        private Transform _playerTransform;

        protected StateMachine StateMachine;

        protected virtual void OnEnable()
        {
            _healthEntity.LostHeath += OnLostHealth;
            _healthEntity.ReachedZeroHealth += OnReachedZeroHealth;
        }

        protected virtual void OnDisable()
        {
            _healthEntity.LostHeath -= OnLostHealth;
            _healthEntity.ReachedZeroHealth -= OnReachedZeroHealth;
        }
        
        protected virtual void Awake()
        {
            _playerTransform = FindObjectOfType<ShipManager>().transform;
        }

        public virtual void MyUpdate()
        {
            StateMachine?.CurrentState.ProcessState();
        }

        public virtual void MyFixedUpdate()
        {
            StateMachine?.CurrentState.ProcessStateFixed();
        }

        private void OnLostHealth()
        {
            TakeDamageFeedback();
        }

        private void OnReachedZeroHealth()
        {
            DeathFeedback();
        }

        protected virtual void TakeDamageFeedback()
        {
            _takeDamagePunchPositionTween.DoTween();
            SFXManager.Instance.QueueSound("Enemy Take Damage");
        }

        protected virtual void DeathFeedback()
        {
            
        }
    }
}