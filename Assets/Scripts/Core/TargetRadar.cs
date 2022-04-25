using System.Collections.Generic;
using UnityEngine;

public class TargetRadar : MonoBehaviour
{
    //Tag of objects to be targeted.
    [SerializeField] string targetTag = "Target";

    List<Collider2D> possibleTargets = new List<Collider2D>();
    GameObject currentTarget = null;

    //Adds to the possibleTargets list all Collider2D that enters the trigger from this.gameObject if their tag is the same as targetTag.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (!possibleTargets.Contains(other))
            {
                possibleTargets.Add(other);
            }
        }
    }

    //Removes from the possibleTargets list all Collider2D that exits the trigger from this.gameObject.
    void OnTriggerExit2D(Collider2D other)
    {
        if (possibleTargets.Contains(other))
        {
            possibleTargets.Remove(other);
        }
    }

    //Searches for closest target every frame.
    void Update()
    {
        currentTarget = FindClosestTarget();
       
            
            if (currentTarget != null)
            {
                Debug.DrawLine(transform.position, currentTarget.transform.position);
            }
        
    }

    //Returns the gameObject with the closest position to this.gameObject from the possibleTargets list.
    GameObject FindClosestTarget()
    {
        float distanceToClosestTarget = Mathf.Infinity;
        Vector3 thisPosition = this.transform.position;
        GameObject closestTarget = null;

        foreach (Collider2D target in possibleTargets)
        {
            Vector3 positionDifference = target.transform.position - thisPosition;
            float distanceToCurrentTarget = positionDifference.sqrMagnitude;
            if (distanceToCurrentTarget < distanceToClosestTarget) {
                distanceToClosestTarget = distanceToCurrentTarget;
                closestTarget = target.gameObject;
                Debug.Log("Exchanged targets");
            }
        }

        return closestTarget;
    }
}
