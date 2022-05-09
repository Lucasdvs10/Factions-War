using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSetupPanel : MonoBehaviour
{   
    public GameObject queuePanel;
    private Queue<GameObject> troops;

     void Start()
    {
        this.troops = new Queue<GameObject>();
    }

    public void AddTroopToQueue(GameObject troop){
        troops.Enqueue(troop);
        GameObject troopImage = Instantiate(troop);
        troopImage.transform.SetParent(queuePanel.transform, false);
    }
}
