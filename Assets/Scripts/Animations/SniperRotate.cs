using UnityEngine;

public class SniperRotate : MonoBehaviour
{   
    private TargetRadar _currentTargetChanged;
    private Transform _currentTargetTransform;
    private Vector3 _vectorDirection;
    private Quaternion _rotation;


    void Start()
    {
        _currentTargetChanged = GetComponent<TargetRadar>();
        _currentTargetChanged.CurrentTargetChangedEvent += RotateSniper;

    }

    void RotateSniper(GameObject _currentTarget)
    {
        if(_currentTarget != null){
            _currentTargetTransform = _currentTarget.GetComponent<Transform>();
        _vectorDirection = (_currentTargetTransform.position - transform.position).normalized;
        _rotation = Quaternion.LookRotation(_vectorDirection);
        transform.rotation = _rotation;
        }   
    }
}
