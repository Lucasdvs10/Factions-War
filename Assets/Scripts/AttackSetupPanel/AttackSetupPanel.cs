using System.Collections.Generic;
using UnityEngine;

public class AttackSetupPanel : MonoBehaviour
{   
    public GameObject queuePanel; 
    private List<GameObject> troopsGameObjList;

     void Start()
    {
        troopsGameObjList = new List<GameObject>();
    }

    public void AddTroopToQueue(GameObject troop){
        troopsGameObjList.Add(troop);
        GameObject troopImage = Instantiate(troop);
        troopImage.transform.SetParent(queuePanel.transform, false);
    }

    public List<GameObject> ListPanel => troopsGameObjList;
}
