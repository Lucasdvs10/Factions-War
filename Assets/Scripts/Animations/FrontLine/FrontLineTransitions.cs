using UnityEngine;

public class FrontLineTransitions : MonoBehaviour
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
        _innerRangeDamage = _range.GetComponent<InnerRangeDamage>();
        _innerRangeDamage.OnDamageBeingApplied += TransitionToShooting;
        _innerRangeDamage.OnDamageNotBeingApplied += TransitionToWalking;

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
