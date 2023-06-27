using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Steering
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SteeringController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private SteeringType _steeringType;
        [ShowIf("_steeringType", SteeringType.Velocity)]
        [SerializeField] private bool _smoothVelocity;
        [ShowIf("_smoothVelocity")]
        [SerializeField] private float _velocitySmoothing = 0.0f;
        [Header("Pilots")]
        [SerializeField] private List<Pilot> _pilots = new();

        public void Steer()
        {
            Move(GetVelocity());
        }

        private Vector2 GetVelocity()
        {
            Vector2 result = Vector2.zero;
            
            foreach (Pilot pilot in _pilots)
            {
                result += pilot.GetSteering() * pilot.Weight;
            }

            return result;
        }

        private void Move(Vector2 velocity)
        {
            switch (_steeringType)
            {
                case SteeringType.Force:
                    _rb.AddForce(velocity);
                    break;
                case SteeringType.Velocity:
                    _rb.velocity = _smoothVelocity ? Vector2.Lerp(_rb.velocity, velocity, Time.deltaTime * _velocitySmoothing) : velocity;
                    break;
                default:
                    break;
            }
        }
    }
}
