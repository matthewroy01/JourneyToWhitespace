using System;
using System.Collections;
using Projectile.Data;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> Destroyed;

        [SerializeField] private Rigidbody2D _rb;
        private ProjectileDefinition _definition;
        private Coroutine _destroyCoroutine;

        public void Initialize(ProjectileDefinition definition)
        {
            _definition = definition;
        }

        public void Move(Vector2 position, Vector2 direction)
        {
            gameObject.SetActive(true);

            transform.position = position;
            
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
            transform.up = direction;
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
            
            Destroyed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}