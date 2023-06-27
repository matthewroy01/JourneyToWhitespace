using System;
using UnityEngine;

namespace CameraStuff
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _shipTransform;
        [SerializeField] private float _followSpeed;
        private Vector3 _targetPosition;
        private Transform _myTransform;
        private Vector3 _myPosition;

        private void Awake()
        {
            _myTransform = transform;
        }

        void FixedUpdate()
        {
            _myPosition = _myTransform.position;
            
            _targetPosition = _shipTransform.position;
            _targetPosition.z = _myPosition.z;

            _myTransform.position = Vector3.Lerp(_myPosition, _targetPosition, Time.deltaTime * _followSpeed);
        }
    }
}