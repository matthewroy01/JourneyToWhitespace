using Ship;
using Steering;
using UnityEngine;

public class OrbitAroundPlayer : Pilot
{
    [SerializeField] private float _gravity;
    [SerializeField] private float _inertia;
    
    private Transform _playerTransform;
    
    private void Awake()
    {
        _playerTransform = FindObjectOfType<ShipManager>().transform;
    }

    public override Vector2 GetSteering()
    {
        Vector2 gravityDirection = (_playerTransform.position - transform.position).normalized;
        Vector2 inertiaDirection = Vector2.Perpendicular(gravityDirection);

        return (gravityDirection * _gravity) + (inertiaDirection * _inertia);
    }
}
