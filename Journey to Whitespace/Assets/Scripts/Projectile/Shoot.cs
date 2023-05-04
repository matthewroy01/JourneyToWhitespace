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
        private readonly List<ProjectileInfo> _extraProjectileInfo = new();

        private Coroutine _muzzleFlareRoutine;

        public void Fire(ProjectileInfo projectileInfo)
        {
            Fire(projectileInfo.GetProjectile(), transform);
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