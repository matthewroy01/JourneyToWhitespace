using System;
using System.Collections.Generic;
using MHR.GameObjectManagement.Pooling;
using Projectile.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Projectile
{
    [Serializable]
    public class ProjectileInfo
    {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private ProjectileDefinition _definition;
        private Pool<Projectile> _pool;
        
        private const int DEFAULT_MAX_PROJECTILES = 30;

        public void Initialize()
        {
            CreatePool();
        }
        
        private void CreatePool()
        {
            _pool = new Pool<Projectile>();
            
            int primaryAmount = _definition.LimitNumberOnScreen ? _definition.MaxNumberOnScreen : DEFAULT_MAX_PROJECTILES;

            List<Projectile> toPool = new();
            
            for (int i = 0; i < primaryAmount; i++)
            {
                Projectile tmp = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
                tmp.Initialize(_definition);
                tmp.Destroyed += OnProjectileDestroyed;
                tmp.gameObject.SetActive(false);
                toPool.Add(tmp);
            }
            
            _pool.Initialize(toPool);
        }
        
        private void OnProjectileDestroyed(Projectile projectile)
        {
            _pool.FreeObject(projectile);
        }

        public Projectile GetProjectile()
        {
            return _pool.GetFreeObject();
        }
    }
}