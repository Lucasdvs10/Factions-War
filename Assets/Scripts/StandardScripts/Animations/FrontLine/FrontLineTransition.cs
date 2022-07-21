using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLineTransition : MonoBehaviour
{
    private Transform _range;
    private InnerRangeDamage _innerRangeDamage; 
    private Animator _frontLineAnimator;
    private TargetRadar _targetRadar;

    void Start()
    {
        _frontLineAnimator = GetComponent<Animator>();
        _frontLineAnimator.SetBool("isShooting", false);
        _range = transform.Find("Range");
        _targetRadar = _range.GetComponent<TargetRadar>();
        _targetRadar.OnDamageBeingApplied += TransitionToShooting;
        _targetRadar.OnDamageNotBeingApplied += TransitionToWalking;

    }

    void TransitionToShooting()
    {
        _frontLineAnimator.SetBool("isShooting", true);
    }

    void TransitionToWalking()
    {
        _frontLineAnimator.SetBool("isShooting", false);
    }

}