using System;
using System.Collections;
using System.Collections.Generic;
using AudioManagement.SFX;
using DG.Tweening;
using Management;
using MHRUtil.DOTween.Transform;
using Projectile.Data;
using UnityEngine;

namespace Projectile
{
    public class Shoot : MonoBehaviour
    {
        private readonly List<ProjectileInfo> _extraProjectileInfo = new();

        private Coroutine _muzzleFlareRoutine;

        public void Fire(ProjectileInfo projectileInfo, Transform sourceTransform = null, Vector2 customDirection = default)
        {
            Projectile projectile = projectileInfo.GetProjectile();
            
            if (projectile == null)
                return;

            if (sourceTransform == null)
            {
                sourceTransform = transform;
            }
            
            projectile.Move(sourceTransform.position, GetDirection(projectileInfo, customDirection));

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

        public void FireExtraProjectile(int index, Transform sourceTransform = null, Vector2 customDirection = default)
        {
            ProjectileInfo projectileInfo = GetProjectileInfoFromExtraPools(index);

            if (sourceTransform == null)
            {
                sourceTransform = transform;
            }

            Fire(projectileInfo, sourceTransform, customDirection);
        }

        private Vector2 GetDirection(ProjectileInfo projectileInfo, Vector2 customDirection = default)
        {
            switch (projectileInfo.DirectionDefinition.ProjectileDirectionType)
            {
                case ProjectileDirectionType.Up:
                    return transform.up;
                case ProjectileDirectionType.Custom:
                    return customDirection;
                case ProjectileDirectionType.Down:
                    return transform.up * -1.0f;
                case ProjectileDirectionType.Left:
                    return transform.right * -1.0f;
                case ProjectileDirectionType.Right:
                    return transform.right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}