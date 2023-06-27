using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Steering
{
    public class AvoidOtherEnemies : Pilot
    {
        [SerializeField] private Enemy.Enemy _myEnemy;
        [SerializeField] private float _minDistance;
        
        public override Vector2 GetSteering()
        {
            List<Enemy.Enemy> enemies = EnemyManager.Instance.GetEnemies();

            List<Enemy.Enemy> closeEnemies = new();
            
            Vector2 myPosition = _myEnemy.transform.position;

            foreach (Enemy.Enemy enemy in enemies)
            {
                if (enemy == _myEnemy)
                    continue;

                if (Vector2.SqrMagnitude(myPosition - (Vector2)enemy.transform.position) <
                    _minDistance * _minDistance)
                {
                    closeEnemies.Add(enemy);
                }
            }

            if (closeEnemies.Count == 0)
                return Vector2.zero;

            Vector2 result = Vector2.zero;

            foreach (Enemy.Enemy closeEnemy in closeEnemies)
            {
                Vector2 closeEnemyPosition = closeEnemy.transform.position;
                
                float distance = Vector2.Distance(myPosition, closeEnemyPosition);

                Vector2 direction = myPosition == closeEnemyPosition ? GetRandomDirection() : myPosition - closeEnemyPosition;

                result += direction * (distance == 0.0f ? 100.0f : _minDistance / distance);
            }

            return result;
        }

        private Vector2 GetRandomDirection()
        {
            float x = Random.Range(-1.0f, 1.0f), y = Random.Range(-1.0f, 1.0f);
            return new Vector2(x, y).normalized;
        }
    }
}
