using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTroopsSpawner : MonoBehaviour
{
    private List<GameObject> _troopsToBeSpawned;

  public void SpawnTroopsInSeconds(float SecondsToSpawnTroop)
    {
        StartCoroutine(SpawnTroopsInSecondsCorotine(SecondsToSpawnTroop));
    }

    public void AddTroopInTheSpawnList(GameObject troop){
        _troopsToBeSpawned.Add(troop);
    }

    private IEnumerator SpawnTroopsInSecondsCorotine(float SecondsToSpawnTroop)
    {
        while (ExistsTroopsInListToBeSpawned())
        {
            yield return new WaitForSeconds(SecondsToSpawnTroop);
            Instantiate(_troopsToBeSpawned[0]);
            _troopsToBeSpawned.RemoveAt(0);
        }
    }

    private bool ExistsTroopsInListToBeSpawned()
    {
        return _troopsToBeSpawned.Count > 0;
    }


    public List<GameObject> TroopsToBeSpawned {
        get => _troopsToBeSpawned;
        set => _troopsToBeSpawned = value;
    }
}