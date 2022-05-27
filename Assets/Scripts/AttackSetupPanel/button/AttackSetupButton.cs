using UnityEngine;

public class AttackSetupButton : MonoBehaviour
{
    public GameObject attackSetupPanel;
    public GameObject troop;

    public void AddTroopToQueue(){
        attackSetupPanel.GetComponent<AttackSetupPanel>().AddTroopToQueue(troop);
    }
}
