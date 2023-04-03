using NaughtyAttributes;
using UnityEngine;

namespace Projectile.Data
{
    [CreateAssetMenu(fileName = "New Projectile Definition", menuName = "Whitespace/Projectile Definition", order = 1)]
    public class ProjectileDefinition : ScriptableObject
    {
        public float Damage => _damage;
        public float ForwardSpeed => _forwardSpeed;
        public float LifetimeDuration => _lifetimeDuration;
        public ProjectileTargetType TargetType => _targetType;
        public bool LimitNumberOnScreen => _limitNumberOnScreen;
        public int MaxNumberOnScreen => _maxNumberOnScreen;
        public bool HasCooldown => _hasCooldown;
        public float Cooldown => _cooldown;
        
        [SerializeField] private float _damage;
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _lifetimeDuration = float.PositiveInfinity;
        [SerializeField] private ProjectileTargetType _targetType;
        [SerializeField] private bool _limitNumberOnScreen;
        [SerializeField, ShowIf("_limitNumberOnScreen")] private int _maxNumberOnScreen;
        [SerializeField] private bool _hasCooldown;
        [SerializeField, ShowIf("_hasCooldown")] private float _cooldown;
    }
}