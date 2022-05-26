using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionsTank : MonoBehaviour
{
    private GameObject[] _isTargetOf;
    private Animator _animator;
    private int _isTarget = 0;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isTargetOf = _getAllThoseWhoAim();
        foreach (GameObject whoAim in _isTargetOf)
        {
            TargetRadar theTarget = whoAim.GetComponentInChildren<TargetRadar>();
            if (theTarget.GetCurrentTarget() != null && theTarget.GetCurrentTarget() == gameObject)
            {
                _isTarget++;
            }
        }
        _isTarget = _isTarget / 2; // Nao entendi o porque de ter que dividir por dois
        Debug.Log(_isTarget);
        if (_isTarget == 0)
        {
            _animator.SetBool("isTarget", false);
            _animator.SetInteger("targetCount", 0);
        }
        else if (_isTarget == 1)
        {
            _animator.SetBool("isTarget", true);
            _isTarget = 0;
        }
        else
        {
            _animator.SetBool("isTarget", true);
            _animator.SetInteger("targetCount", 3);
            _isTarget = 0;
        }
    }

    GameObject[] _getAllThoseWhoAim()
    {
        GameObject[] _arrayOfThoseWhoAim;
        if (gameObject.CompareTag("Attackers"))
        {
            _arrayOfThoseWhoAim = GameObject.FindGameObjectsWithTag("Defenders");
        }
        else
        {
            _arrayOfThoseWhoAim = GameObject.FindGameObjectsWithTag("Attackers");
        }
        return _arrayOfThoseWhoAim;
    }
}
