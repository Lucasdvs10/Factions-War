using UnityEngine;
public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    private float _regularSpeed;

    [SerializeField]
    private float _speedWhenShooting;

    private float _actualSpeed;
    
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        ApplyRegularSpeed();
    }

    private void FixedUpdate()
    {
        //Distance between Attacker and Target
        Vector3 distanceFromTarget = _target.position - transform.position;
        //Normalized gets direction with a given vector
        Vector3 direction = distanceFromTarget.normalized;
        Vector3 velocity = direction * _actualSpeed;
        
        //Changes position of Attacker through time
        _rigidbody.MovePosition(transform.position + (velocity * Time.deltaTime));
    }

    private void ApplySpeedWhenShooting()
    {
        _actualSpeed = _speedWhenShooting;
    }

    private void ApplyRegularSpeed()
    {
        _actualSpeed = _regularSpeed;
    }
}
