using System;
using UnityEngine;

namespace Enemy.SurprisedFace
{
    public class SurprisedFace_Fire : EnemyState
    {
        public event Action<float> GoodToFire;
        public event Action DoneShooting;
        
        [SerializeField] private float _windupDuration;
        [SerializeField] private float _betweenProjectileDuration;
        [SerializeField] private int _numberOfShots;
        private float _timer;
        private int _shotCounter;
        private bool _shooting;
        
        public override void EnterState()
        {
            _timer = 0.0f;
            _shotCounter = 0;
            _shooting = false;
        }

        public override void ExitState() { }

        public override void ProcessState()
        {
            if (_shooting)
            {
                if (_shotCounter >= _numberOfShots)
                {
                    DoneShooting?.Invoke();
                    return;
                }
                
                if (_timer < _betweenProjectileDuration)
                {
                    _timer += Time.deltaTime;
                    return;
                }
                
                GoodToFire?.Invoke(Mathf.Max(1.5f - (0.25f * _shotCounter), 0.75f));
                _timer = 0.0f;
                _shotCounter++;
            }
            else
            {
                if (_timer < _windupDuration)
                {
                    _timer += Time.deltaTime;
                    return;
                }

                _shooting = true;
                _timer = 0.0f;
            }
        }

        public override void ProcessStateFixed() { }
    }
}