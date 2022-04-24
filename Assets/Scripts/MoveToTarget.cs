using UnityEngine;
public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _speedDecrementWhenShooting;
    
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        //ApplySlowness(_speedDecrementWhenShooting);
    }

    private void FixedUpdate()
    {
        //Distance between Attacker and Target
        Vector3 distanceFromTarget = _target.position - transform.position;
        //Normalized gets direction with a given vector
        Vector3 direction = distanceFromTarget.normalized;
        Vector3 velocity = direction * _speed;
        
        //Changes position of Attacker through time
        _rigidbody.MovePosition(transform.position + (velocity * Time.deltaTime));
    }

    private void ApplySlowness(float speedDecrement)
    {
        _speed -= speedDecrement;
    }
}
