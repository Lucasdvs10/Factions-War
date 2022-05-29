using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class RotationTank : MonoBehaviour
{
    private Animator _animator;
    private int _targetCount;
    private TransitionsTank _transitionsTank;
    private GameObject[] _arrayOfThoseWhoShoot;
    private TargetRadar _targetRadarOfThoseWhoAim;


    private void Start()
    {
        _transitionsTank = GetComponent<TransitionsTank>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        foreach (GameObject whoAim in _transitionsTank.GetAllThoseWhoAim())
        {
            _targetRadarOfThoseWhoAim = whoAim.GetComponent<TargetRadar>();
            if (_targetRadarOfThoseWhoAim.GetCurrentTarget() == gameObject)
            {
                _arrayOfThoseWhoShoot.Append(whoAim);
            }
        }
        //todo: pegar todos aqueles que estao atirando no tank, retornar o transform, criar um vetor pensando na posicao media entre os que estao atirando

    }
}
