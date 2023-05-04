using Management;
using UnityEngine;

namespace Projectile
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private ProjectileInfo _primary;
        [SerializeField] private ProjectileInfo _secondary;
        [SerializeField] private Shoot _shoot;
        
        private void Awake()
        {
            InitializeProjectiles();
        }

        private void InitializeProjectiles()
        {
            _primary.Initialize(_shoot);
            _secondary.Initialize(_shoot);
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
            _shoot.Fire(_primary);
        }

        private void OnRightClickPerformed()
        {
            _shoot.Fire(_secondary);
        }
    }
}