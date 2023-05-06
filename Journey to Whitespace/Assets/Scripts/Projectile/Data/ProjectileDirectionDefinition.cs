using System;
using NaughtyAttributes;
using UnityEngine;

namespace Projectile.Data
{
    [Serializable]
    public class ProjectileDirectionDefinition
    {
        public ProjectileDirectionType ProjectileDirectionType => _projectileDirectionType;
        public Transform RelativeTransform => _relativeTransform;
        
        [SerializeField] private ProjectileDirectionType _projectileDirectionType;
        [ShowIf("_projectileDirectionType", ProjectileDirectionType.Up), AllowNesting]
        [SerializeField] private Transform _relativeTransform;
    }
}