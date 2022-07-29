using UnityEngine;

public class FrontLineRotation : MonoBehaviour
{

    private TargetRadar _currentTargetChanged;
    private Transform _currentTargetTransform;
    private Quaternion _initialRotation;

    private void Awake() {
        _currentTargetChanged = GetComponentInChildren<TargetRadar>();
        _initialRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (_currentTargetChanged.GetCurrentTarget() != null)
        {
            _currentTargetTransform = _currentTargetChanged.GetCurrentTarget().GetComponent<Transform>();
            var vectorDirection = (_currentTargetTransform.position - transform.position).normalized;
            var rotation = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = Vector3.forward * rotation;
        }
        else {
            transform.rotation = _initialRotation;
        }


    }



}