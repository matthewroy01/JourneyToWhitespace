using System;
using UnityEngine;

namespace Utility
{
    public class RotateOverTime : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotation;
        
        private void FixedUpdate()
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
    }
}