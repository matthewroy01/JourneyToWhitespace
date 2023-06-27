using AudioManagement.SFX;
using CameraStuff;
using HealthAndDamage;
using UnityEngine;
using Utility;

namespace Ship
{
    public class ShipDamageFeedback : MonoBehaviour
    {
        [SerializeField] private HealthEntity _healthEntity;
        [SerializeField] private TintSprites _tintSprites;
        [SerializeField] private TintSpritesInfo _damageBlinkInfo;
        [SerializeField] private CameraShake _cameraShake;

        private void OnEnable()
        {
            _healthEntity.LostHeath += OnLostHealth;
            _healthEntity.ReachedZeroHealth += OnReachedZeroHealth;
        }

        private void OnDisable()
        {
            _healthEntity.LostHeath -= OnLostHealth;
            _healthEntity.ReachedZeroHealth -= OnReachedZeroHealth;
        }

        private void OnLostHealth()
        {
            _tintSprites.DoColorBlink(_damageBlinkInfo);
            SFXManager.Instance.QueueSound("Player Take Damage");
            _cameraShake.Shake();
        }

        private void OnReachedZeroHealth()
        {
            
        }
    }
}