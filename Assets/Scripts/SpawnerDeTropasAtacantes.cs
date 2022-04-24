using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeTropasAtacantes : MonoBehaviour
{
    private Queue<GameObject> TroopsToBeSpawned;
    public GameObject[] InitializingVectorForTroopQueue;
    void Start()
    {
        this.TroopsToBeSpawned = new Queue<GameObject>(InitializingVectorForTroopQueue);
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

    public void AddTroopInTheSpawnQueue(GameObject tropa){
        TroopsToBeSpawned.Enqueue(tropa);
    }

    private IEnumerator SpawnTroopsInSecondsCorotine(float SecondsToSpawnTroop)
    {
        while (ExistsTroopsInQueueToBeSpawned())
        {
            yield return new WaitForSeconds(SecondsToSpawnTroop);
            Instantiate(TroopsToBeSpawned.Dequeue());
        }
    }

    private bool ExistsTroopsInQueueToBeSpawned()
    {
        return TroopsToBeSpawned.Count > 0;
    }
}
