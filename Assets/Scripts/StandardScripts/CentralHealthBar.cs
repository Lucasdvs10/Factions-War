using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralHealthBar : MonoBehaviour
{
public Transform HealthBar;      //barra de vida verde
public GameObject HealthBarObject; 

private Vector3 _HealthBarScale; //tamanho
private float _HealthPercent;   //porcentagem da vida

public float _towerHealthNew;



    // Start is called before the first frame update
    void Start()
    {
        _towerHealthNew = GetComponent<TowerHealth>()._towerHealth;

    _HealthBarScale = HealthBar.localScale;
    _HealthPercent = _HealthBarScale.x / _towerHealthNew;
        
    }

    void UpdateHealthBar(){

    _HealthBarScale.x = _HealthPercent * _towerHealthNew;
    HealthBar.localScale = _HealthBarScale;
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
