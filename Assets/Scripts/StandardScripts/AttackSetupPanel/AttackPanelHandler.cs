using System.Collections.Generic;
using AttackSetupPanel;
using UnityEngine;

public class AttackPanelHandler : MonoBehaviour
{   
    public GameObject queuePanel; 
    private List<GameObject> troopsGameObjList;

     void Start()
    {
        troopsGameObjList = new List<GameObject>();
    }

    public void AddTroopToQueue(GameObject troop) {
        var troopPrefab = troop.GetComponent<ObjectHandler>().GetTroopPrefab();
        
        troopsGameObjList.Add(troopPrefab);
        GameObject troopImage = Instantiate(troop);
        troopImage.transform.SetParent(queuePanel.transform, false);
    }

    public List<GameObject> ListPanel => troopsGameObjList;
}
