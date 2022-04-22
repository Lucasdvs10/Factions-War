using UnityEngine;
public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    
    void Update()
    {
        //Distance between Attacker and Target
        Vector3 distanceFromTarget = target.position - transform.position;
        //Normalized gets direction with a given vector
        Vector3 direction = distanceFromTarget.normalized;
        Vector3 velocity = direction * speed;
        
        //Changes position of Attacker through time
        transform.Translate(velocity * Time.deltaTime);
    }
}
