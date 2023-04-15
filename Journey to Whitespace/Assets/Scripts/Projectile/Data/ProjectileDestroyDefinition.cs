using NaughtyAttributes;
using UnityEngine;

namespace Projectile.Data
{
    [CreateAssetMenu(fileName = "New Projectile Definition", menuName = "Whitespace/Projectile Destroy Definition", order = 1)]
    public class ProjectileDestroyDefinition : ScriptableObject
    {
        public ProjectileDestroyType ProjectileDestroyType => _projectileDestroyType;
        public ProjectileInfo DestroyProjectile => _destroyProjectile;
        public int Amount => _amount;
        
        [SerializeField] private ProjectileDestroyType _projectileDestroyType;
        [ShowIf("_projectileDestroyType", ProjectileDestroyType.CreateProjectiles)]
        [SerializeField] private ProjectileInfo _destroyProjectile;
        [ShowIf("_projectileDestroyType", ProjectileDestroyType.CreateProjectiles)]
        [SerializeField] private int _amount;
    }
}