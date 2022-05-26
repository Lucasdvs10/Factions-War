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
        _isTargetOf = GetAllThoseWhoAim();
        foreach (GameObject whoAim in _isTargetOf)
        {
            TargetRadar theTarget = whoAim.GetComponentInChildren<TargetRadar>();
            if (theTarget.GetCurrentTarget() == gameObject)
            {
                _isTarget++;
            }
        }
        _isTarget = _isTarget / 2; // Nao entendi o porque de ter que dividir por dois
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

    GameObject[] GetAllThoseWhoAim()
    {
        GameObject[] arrayOfThoseWhoAim;
        if (gameObject.CompareTag("Attackers"))
        {
            arrayOfThoseWhoAim = GameObject.FindGameObjectsWithTag("Defenders");
        }
        else
        {
            arrayOfThoseWhoAim = GameObject.FindGameObjectsWithTag("Attackers");
        }
        return arrayOfThoseWhoAim;
    }
}
