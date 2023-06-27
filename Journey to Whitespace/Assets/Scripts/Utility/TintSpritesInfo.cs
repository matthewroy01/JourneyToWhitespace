using System;
using NaughtyAttributes;
using UnityEngine;

namespace Utility
{
    [Serializable]
    public class TintSpritesInfo
    {
        public Color Color => _color;
        public bool Blink => _blink;
        public float TimeBetweenBlinks => _timeBetweenBlinks;
        public float Duration => _duration;
        
        [SerializeField] private Color _color;
        [SerializeField] private bool _blink;
        [ShowIf("_blink"), AllowNesting]
        [SerializeField] private float _timeBetweenBlinks;
        [ShowIf("_blink"), AllowNesting]
        [SerializeField] private float _duration;
    }
}