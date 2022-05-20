using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTroopsSpawner : MonoBehaviour{
    [SerializeField] private Transform _towerTransform;
    
    private Queue<GameObject> _troopsToBeSpawned;
    public GameObject[] initializingVectorForTroopQueue;
    void Start()
    {
        this._troopsToBeSpawned = new Queue<GameObject>(initializingVectorForTroopQueue);
        SpawnTroopsInSeconds(3.0f);
    }

    public void SpawnTroopsInSeconds(float SecondsToSpawnTroop)
    {
        StartCoroutine(SpawnTroopsInSecondsCorotine(SecondsToSpawnTroop));
    }

    public void AddTroopInTheSpawnQueue(GameObject troop){
        _troopsToBeSpawned.Enqueue(troop);
    }

    private IEnumerator SpawnTroopsInSecondsCorotine(float SecondsToSpawnTroop)
    {
        while (ExistsTroopsInQueueToBeSpawned())
        {
            yield return new WaitForSeconds(SecondsToSpawnTroop);
            var gameobj = Instantiate(_troopsToBeSpawned.Dequeue(), transform.position, Quaternion.identity);
            
            gameobj.GetComponent<MoveToTarget>().SetTarget(_towerTransform);
        }
    }

    private bool ExistsTroopsInQueueToBeSpawned()
    {
        return _troopsToBeSpawned.Count > 0;
    }
}