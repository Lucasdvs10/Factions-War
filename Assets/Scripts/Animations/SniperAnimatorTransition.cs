using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAnimatorTransition : MonoBehaviour
{
    private Transform _range;
    private InnerRangeDamage _innerRangeDamage; 
    private Animator _sniperAnimator;


    void Start()
    {
        _sniperAnimator = GetComponent<Animator>();
        _sniperAnimator.SetBool("isShooting", false);


        _range = transform.Find("Range");
        _innerRangeDamage = _range.GetComponent<InnerRangeDamage>();
        _innerRangeDamage.OnDamageBeingApplied += TransitionToShooting;
        _innerRangeDamage.OnDamageNotBeingApplied += TransitionToWalking;

    }

    void TransitionToShooting()
    {
        _sniperAnimator.SetBool("isShooting", true);
    }

    void TransitionToWalking()
    {
        _sniperAnimator.SetBool("isShooting", false);
    }

}
