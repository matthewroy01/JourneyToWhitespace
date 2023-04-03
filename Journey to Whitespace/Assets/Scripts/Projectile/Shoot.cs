using System.Collections.Generic;
using Management;
using MHR.GameObjectManagement.Pooling;
using Projectile.Data;
using Unity.Mathematics;
using UnityEngine;

namespace Projectile
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private ProjectileInfo _primary;
        [SerializeField] private ProjectileInfo _secondary;


        private void Awake()
        {
            _primary.Initialize();
            _secondary.Initialize();
        }
        
        private void OnEnable()
        {
            InputManager.LeftClickPerformed += OnLeftClickPerformed;
            InputManager.RightClickPerformed += OnRightClickPerformed;
        }

        private void OnDisable()
        {
            InputManager.LeftClickPerformed -= OnLeftClickPerformed;
            InputManager.RightClickPerformed -= OnRightClickPerformed;
        }

        private void OnLeftClickPerformed()
        {
            PrimaryFire();
        }

        private void OnRightClickPerformed()
        {
            SecondaryFire();
        }

        private void PrimaryFire()
        {
            Fire(_primary.GetProjectile());
        }

        private void SecondaryFire()
        {
            Fire(_secondary.GetProjectile());
        }

        private void Fire(Projectile projectile)
        {
            if (projectile == null)
                return;
            
            Transform t = transform;
            projectile.Move(t.position, t.up);
        }
    }
}