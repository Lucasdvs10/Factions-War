using System.Collections;
using Unity;
using UnityEngine;

public class SniperRotation : MonoBehaviour
{

    private TargetRadar _currentTargetChanged;
    private Transform _currentTargetTransform;

    void FixedUpdate()
    {
        _currentTargetChanged = GetComponentInChildren<TargetRadar>();
        if (_currentTargetChanged.GetCurrentTarget() != null)
        {
            _currentTargetTransform = _currentTargetChanged.GetCurrentTarget().GetComponent<Transform>();
            var vectorDirection = (_currentTargetTransform.position - transform.position).normalized;
            var rotation = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = Vector3.forward * rotation;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }



}