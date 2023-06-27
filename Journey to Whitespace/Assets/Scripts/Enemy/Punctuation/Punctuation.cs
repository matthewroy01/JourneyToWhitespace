using System.Collections.Generic;
using MHR.StateMachine;
using UnityEngine;

namespace Enemy.Punctuation
{
    public class Punctuation : Enemy
    {
        [SerializeField] private Punctuation_Move _move;

        protected override void OnEnable()
        {
            base.OnEnable();

            EnemyManager.Instance.TryAddEnemyToList(this);
            
            _move.SetEnemy(this);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void Awake()
        {
            base.Awake();

            _move.SetEnemy(this);

            StateMachine = new StateMachine(_move,
                new Connection(_move));
        }
    }
}
