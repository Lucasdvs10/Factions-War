using System.Collections.Generic;
using UnityEngine;

public class AttackSetupPanel : MonoBehaviour
{   
    public GameObject queuePanel; 
    private Queue<GameObject> troops;

     void Start()
    {
        troops = new Queue<GameObject>();
    }

    public void AddTroopToQueue(GameObject troop){
        troops.Enqueue(troop);
        GameObject troopImage = Instantiate(troop);
        troopImage.transform.SetParent(queuePanel.transform, false);
    }

    public GameObject QueuePanel => queuePanel;
}
