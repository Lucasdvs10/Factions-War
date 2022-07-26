using UnityEngine;

public class TankTransition : MonoBehaviour
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
      
        switch (_isTarget)
        {
            case 0:
                _animator.SetBool("isTarget", false);
                _animator.SetInteger("targetCount", 0);
                break;
            case 1:
                _animator.SetBool("isTarget", true);
                _animator.SetInteger("targetCount", 1);
                _isTarget = 0;
                break;
            default:
                _animator.SetBool("isTarget", true);
                _animator.SetInteger("targetCount", 2);
                _isTarget = 0;
                break;
        }
    }

    public GameObject[] GetAllThoseWhoAim()
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
