using NaughtyAttributes;
using UnityEngine;

namespace Steering
{
    public class Wander : Pilot
    {
        [MinMaxSlider(0.0f, 10.0f)]
        [SerializeField] private Vector2 _timeBetweenDirectionChange;
        private float _timer = float.MaxValue;
        private Vector2 _direction;
        private float _time;
        
        public override Vector2 GetSteering()
        {
            if (_timer > _time)
            {
                _direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                _timer = 0.0f;
                _time = Random.Range(_timeBetweenDirectionChange.x, _timeBetweenDirectionChange.y);
            }
            
            _timer += Time.fixedDeltaTime;

            return _direction;
        }
    }
}
