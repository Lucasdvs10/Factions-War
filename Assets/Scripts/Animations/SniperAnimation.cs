using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    private Animator _animator;
    private InnerRangeDamage _innerRangeDamage;

    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isShooting", false);

        _innerRangeDamage = GetComponent<InnerRangeDamage>();
        _innerRangeDamage.OnDamageBeingApplied += AnimationTransitionToShooting;
    }

    
    void AnimationTransitionToShooting(){
        _animator.SetBool("isShooting", true);
    }
    void AnimationTransitionToWalking(){
        _animator.SetBool("isShooting", false);
    }
}
