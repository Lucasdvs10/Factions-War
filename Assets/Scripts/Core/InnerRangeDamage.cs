using UnityEngine;

public class InnerRangeDamage : MonoBehaviour
{
    private TargetRadar _currentTarget;
    private GameObject _whoToDamage;
    private LifeScript _applyDamage;
    [SerializeField] private float _damage;
    private void Start()
    {
        _currentTarget = GetComponent<TargetRadar>();
    }
    private void Update()
    {
        if (_currentTarget.Get_currentTarget() != null)
        {
            _whoToDamage = _currentTarget.Get_currentTarget();
            _applyDamage = _whoToDamage.GetComponent<LifeScript>();
            _applyDamage.ApplyDamage(_damage);
            
        }
    }
}
