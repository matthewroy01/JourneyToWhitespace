using System;
using System.Collections;
using Enemy.States;
using MHR.StateMachine;
using UnityEngine;

namespace Enemy.AngryFace
{
    public class AngryFace : Enemy
    {
        [Header("Angry Face")]
        [SerializeField] private GameObject _smile;
        [SerializeField] private GameObject _frown;
        [Header("States")]
        [SerializeField] private AngryFace_MoveTowardsPointAroundPlayer _moveTowardsPointAroundPlayer;
        [SerializeField] private AngryFace_ChargeAtPlayer _chargeAtPlayer;
        private Coroutine _takeDamageRoutine;

        protected override void OnEnable()
        {
            base.OnEnable();

            EnemyManager.Instance.TryAddEnemyToList(this);

            _moveTowardsPointAroundPlayer.ReachedTargetPosition += OnReachedTargetPosition;
            _chargeAtPlayer.DoneCharging += OnDoneCharging;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _moveTowardsPointAroundPlayer.ReachedTargetPosition -= OnReachedTargetPosition;
            _chargeAtPlayer.DoneCharging -= OnDoneCharging;
        }

        private void OnReachedTargetPosition()
        {
            StateMachine.TryChangeState(_chargeAtPlayer);
        }

        private void OnDoneCharging()
        {
            StateMachine.TryChangeState(_moveTowardsPointAroundPlayer);
        }

        protected override void Awake()
        {
            base.Awake();
            
            _moveTowardsPointAroundPlayer.SetEnemy(this);
            _chargeAtPlayer.SetEnemy(this);

            StateMachine = new StateMachine(_moveTowardsPointAroundPlayer,
                new Connection(_moveTowardsPointAroundPlayer, _chargeAtPlayer),
                new Connection(_chargeAtPlayer, _moveTowardsPointAroundPlayer));
        }

        protected override void TakeDamageFeedback()
        {
            base.TakeDamageFeedback();
            
            Frown();
        }

        protected override void DeathFeedback()
        {
            base.DeathFeedback();
            
            // TODO: add animation for angry face changing to a frown
        }

        private void Frown()
        {
            if (_takeDamageRoutine != null)
            {
                StopCoroutine(_takeDamageRoutine);
            }

            StartCoroutine(TakeDamageRoutine());
        }

        private IEnumerator TakeDamageRoutine()
        {
            _frown.SetActive(true);
            _smile.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            
            _smile.SetActive(true);
            _frown.SetActive(false);
        }
    }
}