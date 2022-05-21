using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TargetRadar))]
public class InnerRangeDamage : MonoBehaviour
{
    private TargetRadar _targetRadar;
    private GameObject _whoToDamage;
    private LifeScript _lifeScriptFromTarget;
    private bool _canDamage = true;
    public event Action OnDamageBeingApplied;
    public event Action OnDamageNotBeingApplied;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageDelayInSeconds;
    
    
    private void Awake() {
        _targetRadar = GetComponent<TargetRadar>();
    }
    private void OnEnable() {
        _targetRadar.CurrentTargetChangedEvent += UpdateCanDamageBool;
        _targetRadar.CurrentTargetChangedEvent += StartApplyDamageCoroutine;
    }

    private void OnDisable() {
        _targetRadar.CurrentTargetChangedEvent -= UpdateCanDamageBool;
        _targetRadar.CurrentTargetChangedEvent -= StartApplyDamageCoroutine;
    }
    
    private void StartApplyDamageCoroutine(GameObject targetGame) {
        StartCoroutine(ApplyDamageLoopCoroutine(_damageDelayInSeconds, targetGame));
    }
    
    private IEnumerator ApplyDamageLoopCoroutine(float delayInSeconds, GameObject targetGameobj) {
        var counter = 0f;
        while (_canDamage) {
           
            counter += Time.deltaTime;

            if(counter >= delayInSeconds) {
                counter = 0f;
                ApplyDamageToTarget(targetGameobj);
                OnDamageBeingApplied?.Invoke();
            }
            yield return null;
        }
    }

    private void UpdateCanDamageBool(GameObject targetGameobj) {
        if (targetGameobj is null) {
            _canDamage = false;
            OnDamageNotBeingApplied?.Invoke();
            return;
        }

        _canDamage = true;

    }
    

    private void ApplyDamageToTarget(GameObject targetGameobj) {
        SetWhoToDamageGameobj(targetGameobj);
        _lifeScriptFromTarget = _whoToDamage.GetComponent<LifeScript>();
        _lifeScriptFromTarget.ApplyDamage(_damage);
    }

    private void SetWhoToDamageGameobj(GameObject targetGameobj) {
        _whoToDamage = targetGameobj;
    }
}
