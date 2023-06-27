using Management;
using UnityEngine;

namespace Utility
{
    public class LookAtMouse : MonoBehaviour
    {
        [SerializeField] private float _lookSpeed = Mathf.Infinity;
        private Camera _mainCamera;
        private Vector3 _screenPosition;
        private Vector2 _direction;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Look();
        }

        private void Look()
        {
            transform.up = Vector3.Lerp(transform.up, GetLookVector(), Time.deltaTime * _lookSpeed);
        }

        private Vector2 GetLookVector()
        {
            _screenPosition = _mainCamera.WorldToScreenPoint(transform.position);
            _direction = InputManager.MousePosition - (Vector2)_screenPosition;

            return _direction;
        }
    }
}