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
        public ProjectileDirectionDefinition DirectionDefinition => _directionDefinition;
        
        [SerializeField] private ProjectileDefinition _definition;
        [SerializeField] private ProjectileDirectionDefinition _directionDefinition;
        private Projectile _prefab => _definition.Prefab;
        private Pool<Projectile> _pool;
        private int _extraPoolIndex;
        
        private const int DEFAULT_MAX_PROJECTILES = 30;

        public void Initialize(Shoot shoot)
        {
            CreatePool(shoot);
            AddExtraPools(shoot);
        }
        
        private void CreatePool(Shoot shoot)
        {
            _pool = new Pool<Projectile>();
            
            int primaryAmount = _definition.LimitNumberOnScreen ? _definition.MaxNumberOnScreen : DEFAULT_MAX_PROJECTILES;

            List<Projectile> toPool = new();
            
            for (int i = 0; i < primaryAmount; i++)
            {
                Projectile tmp = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
                tmp.Initialize(_definition, _extraPoolIndex, shoot);
                tmp.Destroyed += OnProjectileDestroyed;
                tmp.gameObject.SetActive(false);
                toPool.Add(tmp);
            }
            
            _pool.Initialize(toPool);
        }

        private void AddExtraPools(Shoot shoot)
        {
            if (_definition.DestroyDefinition == null)
                return;
            
            switch (_definition.DestroyDefinition.ProjectileDestroyType)
            {
                case ProjectileDestroyType.None:
                    break;
                case ProjectileDestroyType.CreateProjectiles:
                    _extraPoolIndex = shoot.AddExtraProjectileInfo(_definition.DestroyDefinition.DestroyProjectile);
                    shoot.GetProjectileInfoFromExtraPools(_extraPoolIndex).Initialize(shoot);
                    break;
            }
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