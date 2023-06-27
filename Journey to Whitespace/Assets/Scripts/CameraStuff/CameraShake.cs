using MHRUtil.DOTween.Transform;
using UnityEngine;

namespace CameraStuff
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private ShakePositionTweenHelper _shakePositionTweenHelper;
    
        public void Shake()
        {
            _shakePositionTweenHelper.DoTween();
        }
    }
}