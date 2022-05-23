using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetRadar : MonoBehaviour
{
    //Tag of objects to be targeted.
    [SerializeField] string targetTag = "Target";

    List<Collider2D> possibleTargetsList = new List<Collider2D>();
    private GameObject _currentTarget = null;

    public event Action<GameObject> CurrentTargetChangedEvent;

    public GameObject GetCurrentTarget => _currentTarget; 
    //Adds to the possibleTargets list all Collider2D that enters the trigger from this.gameObject if their tag is the same as targetTag.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (!possibleTargetsList.Contains(other))
            {
                possibleTargetsList.Add(other);
            }
            UpdateClosestTarget();
        }
    }

    //Removes from the possibleTargets list all Collider2D that exits the trigger from this.gameObject.
    void OnTriggerExit2D(Collider2D other)
    {
        if (possibleTargetsList.Contains(other))
        {
            possibleTargetsList.Remove(other);
            UpdateClosestTarget();
        }
    }

    //Searches for closest target every frame.
    void Update() {
        if (_currentTarget != null) {
                Debug.DrawLine(transform.position, _currentTarget.transform.position);
        }
    }
    //Returns the gameObject with the closest position to this.gameObject from the possibleTargets list.
    
    private void UpdateClosestTarget() {
        var oldTarget = _currentTarget;
        _currentTarget = FindClosestTarget();

        if (oldTarget != _currentTarget) {
            CurrentTargetChangedEvent?.Invoke(_currentTarget);
        }
    }


    private GameObject FindClosestTarget() {
        if (possibleTargetsList.Count <= 0) return null;
        
        
        var closestTargetDistance = Mathf.Infinity;
        var closestTargetGameobj = gameObject;

        foreach (var target in possibleTargetsList) {
            var currentDistanceTarget = Vector3.Distance(target.transform.position, transform.position);

            if (currentDistanceTarget < closestTargetDistance) {
                closestTargetDistance = currentDistanceTarget;
                closestTargetGameobj = target.gameObject;
            }
        }

        return closestTargetGameobj;

    }


}