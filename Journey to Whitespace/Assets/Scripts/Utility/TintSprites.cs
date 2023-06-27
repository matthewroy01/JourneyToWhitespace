using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class TintSprites : MonoBehaviour
    {
        public event Action DoneBlinking;
        
        [SerializeField] private List<SpriteRenderer> _spriteRenderers = new();
        private readonly List<Color> _defaultColors = new List<Color>();
        private Coroutine _colorRoutine;
        private bool _blinking;

        private void Awake()
        {
            if (_spriteRenderers == null)
            {
                Debug.LogWarning("SpriteRenderer of TintSprites on GameObject \"" + gameObject.name + "\" has not been assigned.");
                return;
            }
            
            foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
            {
                _defaultColors.Add(spriteRenderer.color);
            }
        }

        public void SetColor(TintSpritesInfo tintSpritesInfo)
        {
            _spriteRenderers.ForEach(spriteRenderer => spriteRenderer.color = tintSpritesInfo.Color);

            if (tintSpritesInfo.Duration <= 0.0f)
                return;

            if (_colorRoutine != null)
            {
                StopCoroutine(_colorRoutine);
            }
            _colorRoutine = StartCoroutine(ColorRoutine(tintSpritesInfo.Duration));
        }

        public void DoColorBlink(TintSpritesInfo tintSpritesInfo)
        {
            if (tintSpritesInfo.Duration <= 0.0f || tintSpritesInfo.Blink == false)
                return;

            _blinking = true;
            
            if (_colorRoutine != null)
            {
                StopCoroutine(_colorRoutine);
            }
            _colorRoutine = StartCoroutine(BlinkRoutine(tintSpritesInfo.Color, tintSpritesInfo.TimeBetweenBlinks, tintSpritesInfo.Duration));
        }

        public void ResetColor()
        {
            for (int i = 0; i < _spriteRenderers.Count; ++i)
            {
                _spriteRenderers[i].color = _defaultColors[i];
            }
        }

        private IEnumerator ColorRoutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            
            ResetColor();
        }

        private IEnumerator BlinkRoutine(Color color, float timeBetweenBlinks, float duration)
        {
            float timer = 0.0f;
            _blinking = true;

            while (timer <= duration)
            {
                for (int i = 0; i < _spriteRenderers.Count; ++i)
                {
                    _spriteRenderers[i].color = _blinking ? color : _defaultColors[i];
                }
                
                yield return new WaitForSeconds(timeBetweenBlinks);

                timer += timeBetweenBlinks;
                _blinking = !_blinking;
            }
            
            DoneBlinking?.Invoke();
            ResetColor();
        }
    }
}