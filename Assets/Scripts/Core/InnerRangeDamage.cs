using System;
using System.Collections;
using UnityEngine;

public class InnerRangeDamage : MonoBehaviour
{
    private TargetRadar _currentTarget;
    private GameObject _whoToDamage;
    private LifeScript _lifeScriptFromTarget;
    private bool _canDamageloop = true;
    
    
    [SerializeField] private float _damage;
    [SerializeField] private float _damageDelayInSeconds;
    
    
    private void Awake() {
        _currentTarget = GetComponent<TargetRadar>();
        
    }

    private void OnEnable() {
        _currentTarget.OnGetCurrentTargetEvent += StartApplyDamageCoroutine;
        _currentTarget.CurrentTargetChangedEvent += StopApplyDamageCoroutine;
    }

    private void OnDisable() {
        _currentTarget.OnGetCurrentTargetEvent -= StartApplyDamageCoroutine;
        _currentTarget.CurrentTargetChangedEvent -= StopApplyDamageCoroutine;
    }

    private void StopApplyDamageCoroutine() {
        _canDamageloop = false;
        StopCoroutine(ApplyDamageLoopCoroutine(_damageDelayInSeconds, null));
    }

    private void StartApplyDamageCoroutine(GameObject targetGame) {
        _canDamageloop = true;
        StartCoroutine(ApplyDamageLoopCoroutine(_damageDelayInSeconds, targetGame));
    }
    
    //todo: O erro está aqui! Esse loop nunca para de tocar
    private IEnumerator ApplyDamageLoopCoroutine(float delayInSeconds, GameObject targetGameobj) {
        while (true) {
            if(!_canDamageloop) {
                break;
            }
            ApplyDamageToTarget(targetGameobj);
         yield return new WaitForSeconds(delayInSeconds);
        }
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
