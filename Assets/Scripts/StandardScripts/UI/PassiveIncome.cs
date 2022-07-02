using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [SerializeField] private float _startTime = 2.0f;
    [SerializeField] private float _secondsBetweenRepeat = 2.0f;
    [SerializeField] private int _passiveValue = 0;

    //Calls AddPassiveIncome() function after startTime seconds and every time secondsBetweenRepeat seconds passes.
    void Start()
    {
        InvokeRepeating("AddPassiveIncome", _startTime, _secondsBetweenRepeat);
    }

    //Adds passiveValue to game money.
    void AddPassiveIncome()
    {
        gameObject.GetComponent<CurrentMoney>().UpdateMoney(_passiveValue);
    }
}
