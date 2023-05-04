using System.Collections;
using AudioManagement.SFX;
using Enemy.States;
using MHR.StateMachine;
using Projectile;
using UnityEngine;

namespace Enemy.SurprisedFace
{
    public class SurprisedFace : Enemy
    {
        [Header("Surprised Face")]
        [SerializeField] private GameObject _openLeftEye;
        [SerializeField] private GameObject _openRightEye;
        [SerializeField] private GameObject _closedLeftEye;
        [SerializeField] private GameObject _closedRightEye;
        [SerializeField] private GameObject _closedMouth;
        [SerializeField] private GameObject _openMouth;
        [Header("Shooting")]
        [SerializeField] private Shoot _shoot;
        [SerializeField] private ProjectileInfo _projectile;
        [Header("States")]
        [SerializeField] private SurprisedFace_MoveAway _moveAway;
        [SerializeField] private SurprisedFace_Fire _fire;
        private Coroutine _takeDamageRoutine;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _projectile.Initialize(_shoot);
            
            EnemyManager.Instance.TryAddEnemyToList(this);

            _moveAway.ReachedTargetPosition += OnReachedTargetPosition;
            _fire.GoodToFire += OnGoodToFire;
            _fire.DoneShooting += OnDoneShooting;
        }

        protected override void OnDisable()
        {
            _moveAway.ReachedTargetPosition -= OnReachedTargetPosition;
            _fire.GoodToFire -= OnGoodToFire;
            _fire.DoneShooting -= OnDoneShooting;
        }

        private void OnReachedTargetPosition()
        {
            StateMachine.TryChangeState(_fire);
            
            _closedMouth.SetActive(false);
            _openMouth.SetActive(true);
        }

        private void OnGoodToFire()
        {
            Fire(_projectile.GetProjectile(), _openMouth.transform);   
        }

        private void OnDoneShooting()
        {
            StateMachine.TryChangeState(_moveAway);
            
            _closedMouth.SetActive(true);
            _openMouth.SetActive(false);
        }

        protected override void Awake()
        {
            base.Awake();
            
            _moveAway.SetEnemy(this);
            _fire.SetEnemy(this);

            StateMachine = new StateMachine(_moveAway,
                new Connection(_moveAway, _fire),
                new Connection(_fire, _moveAway));
        }

        protected override void TakeDamageFeedback()
        {
            base.TakeDamageFeedback();

            CloseEyes();
        }

        private void CloseEyes()
        {
            if (_takeDamageRoutine != null)
            {
                StopCoroutine(_takeDamageRoutine);
            }

            StartCoroutine(TakeDamageRoutine());
        }

        private IEnumerator TakeDamageRoutine()
        {
            _openLeftEye.SetActive(false);
            _openRightEye.SetActive(false);
            _closedLeftEye.SetActive(true);
            _closedRightEye.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            
            _openLeftEye.SetActive(true);
            _openRightEye.SetActive(true);
            _closedLeftEye.SetActive(false);
            _closedRightEye.SetActive(false);
        }
        
        private void Fire(Projectile.Projectile projectile, Transform t)
        {
            if (projectile == null)
                return;
            
            projectile.Move(t.position, PlayerTransform.position - transform.position);

            SFXManager.Instance.QueueSound(string.IsNullOrEmpty(projectile.CustomSoundName) ? "Shoot" : projectile.CustomSoundName);
        }

        public int AddExtraProjectileInfo(ProjectileInfo projectileInfo)
        {
            throw new System.NotImplementedException();
        }

        public ProjectileInfo GetProjectileInfoFromExtraPools(int index)
        {
            throw new System.NotImplementedException();
        }

        public void FireExtraProjectile(int index, Transform t)
        {
            throw new System.NotImplementedException();
        }
    }
}
