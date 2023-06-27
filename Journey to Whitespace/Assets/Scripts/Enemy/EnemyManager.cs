using System;
using System.Collections.Generic;
using MHRUtil.Singletons;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        private readonly List<Enemy> _enemies = new();

        protected override void Awake()
        {
            base.Awake();
            
            FindEnemiesAlreadyInScene();
        }

        private void FindEnemiesAlreadyInScene()
        {
            // ideally, there won't be any enemies already in the scene, but I'll keep this here so it's easier to test enemies
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                if (!_enemies.Contains(enemy))
                {
                    _enemies.Add(enemy);
                }
            }
        }

        private void Update()
        {
            _enemies.ForEach(enemy => enemy.MyUpdate());
        }

        private void FixedUpdate()
        {
            _enemies.ForEach(enemy => enemy.MyFixedUpdate());
        }

        public void TryAddEnemyToList(Enemy enemy)
        {
            if (_enemies.Contains(enemy))
            {
                return;
            }
            
            _enemies.Add(enemy);
        }

        public List<Enemy> GetEnemies()
        {
            return _enemies;
        }
    }
}