using System;
using System.Collections;
using MHRUtil.Interfaces;
using UnityEngine;

namespace HealthAndDamage
{
    public class HealthEntity : MonoBehaviour, IResettable
    {
        public event Action LostHeath;
        public event Action GainedHealth;
        public event Action TookZeroDamage;
        public event Action ReachedZeroHealth;

        public int CurrentHealth => _currentHealth;

        [SerializeField] private int _maxHealth = 1;
        [SerializeField] private HealthTargetType _healthTargetType;
        [SerializeField] private float _invulnerabilityTime = 0.0f;
        private int _currentHealth;
        private bool _invulnerable;
        private Coroutine _invulnerabilityCoroutine;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            DamageEntity damageEntity = other.gameObject.GetComponent<DamageEntity>();

            if (damageEntity == null)
                return;
            
            if (damageEntity.Source == this)
                return;

            TryTakeDamage(damageEntity);
        }

        private void TryTakeDamage(DamageEntity damageEntity)
        {
            if (_invulnerable)
                return;
            
            DamageTargetType damageTargetType = damageEntity.DamageTargetType;

            switch(_healthTargetType)
            {
                case HealthTargetType.None:
                    TakeDamage(damageEntity.Damage);
                    break;
                case HealthTargetType.Enemy:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Enemy
                        or DamageTargetType.EnemyAndPlayer or DamageTargetType.EnemyAndStructure)
                    {
                        TakeDamage(damageEntity.Damage);
                        damageEntity.TellDealtDamage();
                    }
                    break;
                case HealthTargetType.Player:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Player
                        or DamageTargetType.EnemyAndPlayer or DamageTargetType.PlayerAndStructure)
                    {
                        TakeDamage(damageEntity.Damage);
                        damageEntity.TellDealtDamage();
                    }
                    break;
                case HealthTargetType.Structure:
                    if (damageTargetType is DamageTargetType.All or DamageTargetType.Structure
                        or DamageTargetType.EnemyAndStructure or DamageTargetType.PlayerAndStructure)
                    {
                        TakeDamage(damageEntity.Damage);
                        damageEntity.TellDealtDamage();
                    }
                    break;
                case HealthTargetType.Projectile:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TakeDamage(int amount)
        {
            if (_invulnerabilityTime > 0.0f)
            {
                _invulnerabilityCoroutine = StartCoroutine(Invulnerability());
            }
            
            AdjustHealth(-amount);
        }

        public void RestoreHealth(int amount)
        {
            AdjustHealth(amount);
        }

        public void RestoreAllHealth()
        {
            RestoreHealth(_maxHealth - _currentHealth);
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
            if (_currentHealth + amount <= 0)
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

        private IEnumerator Invulnerability()
        {
            _invulnerable = true;

            yield return new WaitForSeconds(_invulnerabilityTime);
            
            _invulnerable = false;
        }

        public void Reset()
        {
            if (_invulnerabilityCoroutine != null)
            {
                StopCoroutine(_invulnerabilityCoroutine);
            }

            _invulnerable = false;
        }
    }
}