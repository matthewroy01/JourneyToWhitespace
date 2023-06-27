using UnityEngine;

namespace Steering
{
    public abstract class Pilot : MonoBehaviour
    {
        public float Weight;
        
        public abstract Vector2 GetSteering();
    }
}