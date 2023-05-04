using System;
using UnityEngine;

namespace HealthAndDamage
{
    public class HealthEntity : MonoBehaviour
    {
        public event Action LostHeath;
        public event Action GainedHealth;
        public event Action TookZeroDamage;
        public event Action ReachedZeroHealth;

        [SerializeField] private int _maxHealth = 1;
        [SerializeField] private HealthTargetType _healthTargetType;
        //[SerializeField] private LayerMask _damageLayerMask;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // TODO: check layer of collided object?
            //if (_damageLayerMask == (_damageLayerMask | (1 << other.gameObject.layer)))

            DamageEntity damageEntity = other.gameObject.GetComponent<DamageEntity>();

            if (damageEntity == null)
                return;
            
            if (damageEntity.Source == this)
                return;

            TryTakeDamage(damageEntity);
        }

        private void TryTakeDamage(DamageEntity damageEntity)
        {
            DamageTargetType damageTargetType = damageEntity.DamageTargetType;

            switch(_healthTargetType)
            {
                case HealthTargetType.None:
                    TakeDamage(damageEntity.Damage);
                    break;
                case HealthTargetType.Enemy:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Enemy or DamageTargetType.EnemyAndPlayer or DamageTargetType.EnemyAndStructure)
                        TakeDamage(damageEntity.Damage);
                    break;
                case HealthTargetType.Player:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Player or DamageTargetType.EnemyAndPlayer or DamageTargetType.PlayerAndStructure)
                        TakeDamage(damageEntity.Damage);
                    break;
                case HealthTargetType.Structure:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Structure or DamageTargetType.EnemyAndStructure or DamageTargetType.PlayerAndStructure)
                        TakeDamage(damageEntity.Damage);
                    break;
            }
        }

        public void TakeDamage(int amount)
        {
            AdjustHealth(-amount);
        }

        public void RestoreHealth(int amount)
        {
            AdjustHealth(amount);
        }

        private void AdjustHealth(int amount)
        {
            // restoring health and reaching max
            if (_currentHealth + amount > _maxHealth)
            {
                if (_currentHealth < _maxHealth)
                {
                    GainedHealth?.Invoke();
                }
            
                _currentHealth = _maxHealth;
                return;
            }

            // taking damage and reaching zero
            if (_currentHealth + amount < 0)
            {
                if (_currentHealth > 0)
                {
                    LostHeath?.Invoke();
                    ReachedZeroHealth?.Invoke();
                }
            
                _currentHealth = 0;
                return;
            }

            // restoring health or taking damage normally
            if (amount > 0)
            {
                GainedHealth?.Invoke();
            }
            else if (amount < 0)
            {
                LostHeath?.Invoke();
            }
            else
            {
                TookZeroDamage?.Invoke();
            }

            _currentHealth += amount;
        }
    }
}