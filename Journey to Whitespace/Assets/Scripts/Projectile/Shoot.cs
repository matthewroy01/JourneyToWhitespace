using System.Collections;
using System.Collections.Generic;
using AudioManagement.SFX;
using DG.Tweening;
using Management;
using MHRUtil.DOTween.Transform;
using UnityEngine;

namespace Projectile
{
    public class Shoot : MonoBehaviour
    {
        [Header("Projectiles")]
        [SerializeField] private ProjectileInfo _primary;
        [SerializeField] private ProjectileInfo _secondary;
        private readonly List<ProjectileInfo> _extraProjectileInfo = new();

        private Coroutine _muzzleFlareRoutine;

        private void Awake()
        {
            InitializeProjectiles();
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

        private void InitializeProjectiles()
        {
            _primary.Initialize(this);
            _secondary.Initialize(this);
        }

        private void PrimaryFire()
        {
            Fire(_primary.GetProjectile(), transform);
        }

        private void SecondaryFire()
        {
            Fire(_secondary.GetProjectile(), transform);
        }

        private void Fire(Projectile projectile, Transform t)
        {
            if (projectile == null)
                return;
            
            projectile.Move(t.position, t.up);

            SFXManager.Instance.QueueSound(string.IsNullOrEmpty(projectile.CustomSoundName) ? "Shoot" : projectile.CustomSoundName);
        }

        public int AddExtraProjectileInfo(ProjectileInfo projectileInfo)
        {
            _extraProjectileInfo.Add(projectileInfo);
            return _extraProjectileInfo.Count - 1;
        }

        public ProjectileInfo GetProjectileInfoFromExtraPools(int index)
        {
            return _extraProjectileInfo[index];
        }

        public void FireExtraProjectile(int index, Transform t)
        {
            Projectile projectile = GetProjectileInfoFromExtraPools(index).GetProjectile();

            Fire(projectile, t);
        }
    }
}