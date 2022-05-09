using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSetupButton : MonoBehaviour
{
    public GameObject attackSetupPanel;
    public GameObject troop;

    public void AddTroopToQueue(){
        attackSetupPanel.GetComponent<AttackSetupPanel>().AddTroopToQueue(troop);
    }
}
