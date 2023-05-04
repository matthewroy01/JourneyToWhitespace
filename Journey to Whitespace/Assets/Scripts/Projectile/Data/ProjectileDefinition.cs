using HealthAndDamage;
using NaughtyAttributes;
using UnityEngine;

namespace Projectile.Data
{
    [CreateAssetMenu(fileName = "New Projectile Definition", menuName = "Whitespace/Projectile Definition", order = 1)]
    public class ProjectileDefinition : ScriptableObject
    {
        public Projectile Prefab => _prefab;
        public int Damage => _damage;
        public float ForwardSpeed => _forwardSpeed;
        public bool FaceMovementDirection => _faceMovementDirection;
        public float LifetimeDuration => _lifetimeDuration;
        public DamageTargetType TargetType => _targetType;
        public bool LimitNumberOnScreen => _limitNumberOnScreen;
        public int MaxNumberOnScreen => _maxNumberOnScreen;
        public bool HasCooldown => _hasCooldown;
        public float Cooldown => _cooldown;
        public ProjectileDestroyDefinition DestroyDefinition => _destroyDefinition;
        public string CustomSoundName => _customSoundName;

        [SerializeField] private Projectile _prefab;
        [Header("Stats")]
        [SerializeField] private int _damage;
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private bool _faceMovementDirection = true;
        [SerializeField] private float _lifetimeDuration = float.PositiveInfinity;
        [SerializeField] private DamageTargetType _targetType;
        [SerializeField] private bool _limitNumberOnScreen;
        [SerializeField, ShowIf("_limitNumberOnScreen")] private int _maxNumberOnScreen;
        [SerializeField] private bool _hasCooldown;
        [SerializeField, ShowIf("_hasCooldown")] private float _cooldown;
        [SerializeField] private ProjectileDestroyDefinition _destroyDefinition;
        [SerializeField] private string _customSoundName = "";
    }
}