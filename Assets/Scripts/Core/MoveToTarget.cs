using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    
    [SerializeField]
    private float _regularSpeed;

    [SerializeField]
    private float _speedWhenShooting;

    private float _actualSpeed;
    
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ApplyRegularSpeed();
    }

    private void FixedUpdate()
    {
        if(_targetTransform != null) {
            ApplyVelocity();
        }
    }

    private void ApplyVelocity() {
        //Distance between Attacker and Target
        Vector3 distanceFromTarget = _targetTransform.position - transform.position;
        //Normalized gets direction with a given vector
        Vector3 direction = distanceFromTarget.normalized;
        Vector3 velocity = direction * _actualSpeed;

        //Changes position of Attacker through time
        _rigidbody.velocity = velocity;
    }

    private void ApplySpeedWhenShooting()
    {
        _actualSpeed = _speedWhenShooting;
    }

    private void ApplyRegularSpeed()
    {
        _actualSpeed = _regularSpeed;
    }

    public void SetTarget(Transform targetGameobj) {
        _targetTransform = targetGameobj;
    }
}
