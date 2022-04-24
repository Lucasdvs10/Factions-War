using UnityEngine;
public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    private float _speed;
    
    void Update()
    {
        //Distance between Attacker and Target
        Vector3 distanceFromTarget = _target.position - transform.position;
        
        //Normalized gets direction with a given vector
        Vector3 direction = distanceFromTarget.normalized;
        Vector3 velocity = direction * _speed;
        
        //Changes position of Attacker through time
        transform.Translate(velocity * Time.deltaTime);
    }
}
