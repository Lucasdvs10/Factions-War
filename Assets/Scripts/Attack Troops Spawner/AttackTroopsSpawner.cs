using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTroopsSpawner : MonoBehaviour
{
    private Queue<GameObject> _troopsToBeSpawned;
    public GameObject[] initializingVectorForTroopQueue;
    void Start()
    {
        this._troopsToBeSpawned = new Queue<GameObject>(initializingVectorForTroopQueue);
        SpawnTroopsInSeconds(3.0f);
    }

    // Update is called once per frame
    void Update()
    {

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
            Instantiate(_troopsToBeSpawned.Dequeue());
        }
    }

    private bool ExistsTroopsInQueueToBeSpawned()
    {
        return _troopsToBeSpawned.Count > 0;
    }
}