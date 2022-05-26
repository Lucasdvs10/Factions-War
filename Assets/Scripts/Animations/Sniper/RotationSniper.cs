using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class RotationSniper : MonoBehaviour
{   
    
    private TargetRadar _currentTargetChanged;
    private Transform _currentTargetTransform;

    void Start()
    {
        _currentTargetChanged = GetComponentInChildren<TargetRadar>();
        _currentTargetChanged.CurrentTargetChangedEvent += RotateSniper;
    }

    void RotateSniper(GameObject _currentTarget)
    {
        if (_currentTarget != null)
        {
            _currentTargetTransform = _currentTarget.GetComponent<Transform>();
            var vectorDirection = (_currentTargetTransform.position - transform.position).normalized;
            var rotation = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = Vector3.forward * rotation;
        }
        else {
            transform.rotation = Quaternion.identity;
        }
    }




}
