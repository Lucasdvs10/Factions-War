using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class TankRotation : MonoBehaviour
{
    private Animator _animator;
    private int _targetCount;
    private TankTransition _tankTransition;
    private GameObject[] _arrayOfThoseWhoShoot;
    private float[] _abscsissa;
    private float[] _ordered;
    private TargetRadar _targetRadarOfThoseWhoAim;


    private void Start()
    {   
        _tankTransition = GetComponent<TankTransition>();
        _animator = GetComponent<Animator>();
    }

    private void Update()

    //todo: corrigir o bug do null reference e tentar melhorar o codigo.
    {
        foreach (GameObject whoAim in _tankTransition.GetAllThoseWhoAim())
        {
            _targetRadarOfThoseWhoAim = whoAim.GetComponent<TargetRadar>();
            if (_targetRadarOfThoseWhoAim.GetCurrentTarget() == gameObject) //null reference here! 
            {
                _arrayOfThoseWhoShoot.Append(whoAim);
            }
        }
        if (_arrayOfThoseWhoShoot != null)
        {
            foreach (GameObject whoShoot in _arrayOfThoseWhoShoot)
            {   
                _abscsissa.Append(whoShoot.transform.position.x);
                _ordered.Append(whoShoot.transform.position.y);
            }
            float averageX = GetTheAveragePosition(_abscsissa);
            float averageY = GetTheAveragePosition(_ordered);
            Vector3 averagePoint = new Vector3(averageX,averageY, 0);
            var vectorDirection = (averagePoint - transform.position).normalized;
            var rotation = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = Vector3.forward * rotation;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        
    }
        //todo: pegar todos aqueles que estao atirando no tank, retornar o transform, criar um vetor pensando na posicao media entre os que estao atirando

    public float GetTheAveragePosition(float[] axle){
        float sum = 0;
        for(int i = 0; i < axle.Length; i++){
            sum += axle[i];
        }
        float averagePosition = sum / axle.Length;
        return averagePosition;
    }
}
