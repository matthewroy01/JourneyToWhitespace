using UnityEngine;

namespace HealthAndDamage
{
    public class DamageEntity : MonoBehaviour
    {
        public int Damage => _damage;
        public DamageTargetType DamageTargetType => _damageTargetType;
        public HealthEntity Source => _source;
    
        [SerializeField] private int _damage = 1;
        [SerializeField] private DamageTargetType _damageTargetType;
        private HealthEntity _source;

        public void Initialize(HealthEntity source)
        {
            _source = source;
        }

        public void Initialize(int damage, DamageTargetType damageTargetType, HealthEntity source = null)
        {
            _damage = damage;
            _damageTargetType = damageTargetType;
            _source = source;
        }
    }
}