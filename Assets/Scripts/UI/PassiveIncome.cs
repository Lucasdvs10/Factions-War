using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [SerializeField] float startTime = 2.0f;
    [SerializeField] float secondsBetweenRepeat = 2.0f;
    [SerializeField] int passiveValue = 0;

    //Calls AddPassiveIncome() function after startTime seconds and every time secondsBetweenRepeat seconds passes.
    void Start()
    {
        InvokeRepeating("AddPassiveIncome", startTime, secondsBetweenRepeat);
    }

    //Adds passiveValue to game money.
    void AddPassiveIncome()
    {
        gameObject.GetComponent<CurrentMoney>().UpdateMoney(passiveValue);
    }
}
