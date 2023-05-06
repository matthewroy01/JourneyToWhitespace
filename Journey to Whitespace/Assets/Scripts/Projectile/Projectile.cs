using System;
using System.Collections;
using HealthAndDamage;
using Projectile.Data;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> Destroyed;

        public string CustomSoundName => _definition.CustomSoundName;

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private DamageEntity _damageEntity;
        [SerializeField] private HealthEntity _healthEntity;
        [SerializeField] private ParticleSystem _hitParticleSystem;
        private ProjectileDefinition _definition;
        private int _extraPoolIndex;
        private Shoot _shoot;
        private Coroutine _destroyCoroutine;
        private bool _reachedZeroHealth;

        private void OnEnable()
        {
            if (_healthEntity != null)
            {
                _healthEntity.ReachedZeroHealth += OnReachedZeroHealth;
            }

            if (_damageEntity != null)
            {
                _damageEntity.DealtDamage += OnDealtDamage;
            }
        }

        private void OnDisable()
        {
            if (_healthEntity != null)
            {
                _healthEntity.ReachedZeroHealth -= OnReachedZeroHealth;
            }

            if (_damageEntity != null)
            {
                _damageEntity.DealtDamage -= OnDealtDamage;
            }
        }

        private void OnDealtDamage()
        {
            if (_healthEntity == null)
                return;
            
            Debug.Log("reached zero health, health was " + _healthEntity.CurrentHealth);

            _healthEntity.TakeDamage(1);
        }

        private void Update()
        {
            if (!_reachedZeroHealth)
                return;

            DiedFromHittingSomething();
            _reachedZeroHealth = false;
        }

        private void OnReachedZeroHealth()
        {
            _reachedZeroHealth = true;
        }

        public void Initialize(ProjectileDefinition definition, int extraProjectileIndex, Shoot shoot)
        {
            _definition = definition;
            _extraPoolIndex = extraProjectileIndex;
            _shoot = shoot;

            if (_damageEntity != null)
            {
                _damageEntity.Initialize(_definition.Damage, _definition.TargetType);
            }
        }

        public void Move(Vector2 position, Vector2 direction)
        {
            gameObject.SetActive(true);

            transform.position = position;

            direction = direction.normalized;
            SetVelocity(direction);

            if (_destroyCoroutine != null)
            {
                StopCoroutine(_destroyCoroutine);
            }
            _destroyCoroutine = StartCoroutine(DestroyRoutine());
        }

        private void SetVelocity(Vector2 direction)
        {
            _rb.velocity = direction * _definition.ForwardSpeed;
            if (_definition.FaceMovementDirection)
            {
                transform.up = direction;
            }
        }

        private void DiedFromHittingSomething()
        {
            Instantiate(_hitParticleSystem, transform.position, Quaternion.identity);
            DestroyImmediately();
        }
        
        private IEnumerator DestroyRoutine()
        {
            // TODO: keep track of when projectile goes off-screen

            float time = 0.0f;
            while (time < _definition.LifetimeDuration)
            {
                time += Time.deltaTime;
                yield return null;
            }
            
            HandleDestroy();
            
            Destroyed?.Invoke(this);
            gameObject.SetActive(false);
        }

        private void DestroyImmediately()
        {
            StopCoroutine(_destroyCoroutine);
            
            HandleDestroy();
            
            Destroyed?.Invoke(this);
            gameObject.SetActive(false);
        }

        private void HandleDestroy()
        {
            // TODO: add universal destroy vfx?
            
            if (_healthEntity != null)
            {
                _healthEntity.RestoreAllHealth();
            }

            if (_definition.DestroyDefinition == null)
                return;
            
            switch (_definition.DestroyDefinition.ProjectileDestroyType)
            {
                case ProjectileDestroyType.None:
                    break;
                case ProjectileDestroyType.CreateProjectiles:
                    _shoot.FireExtraProjectile(_extraPoolIndex, transform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}