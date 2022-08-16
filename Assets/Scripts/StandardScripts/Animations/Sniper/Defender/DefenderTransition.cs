using System.Collections;
using UnityEngine;

public class DefenderTransition : MonoBehaviour
{
    private Animator _animator;
    void Start() {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            StartCoroutine(SetAnimationForSecondsCoroutine());
        }
    }

    private IEnumerator SetAnimationForSecondsCoroutine() {
        _animator.SetBool("Shooting", true);
        yield return new WaitForSeconds(0.4f);
        _animator.SetBool("Shooting", false);
    }
}