using System.Collections;
using System.Collections.Generic;
using StandardScripts.AttackManager;
using UnityEngine;

public class AttackTroopsSpawner : MonoBehaviour{
    [SerializeField] private Transform _towerTransform;
    
    private List<GameObject> _troopsToBeSpawnedList;
    void Awake()
    {
        _troopsToBeSpawnedList = new List<GameObject>();
    }

    public void SpawnTroopsInSeconds(float SecondsToSpawnTroop, Quaternion direction)
    {
        StartCoroutine(SpawnTroopsInSecondsCorotine(SecondsToSpawnTroop, direction));
    }

    public void AddTroopInTheSpawnQueue(GameObject troop){
        _troopsToBeSpawnedList.Add(troop);
    }

    private IEnumerator SpawnTroopsInSecondsCorotine(float SecondsToSpawnTroop, Quaternion direction) {

        while (ExistsTroopsInQueueToBeSpawned())
        {
            yield return new WaitForSeconds(SecondsToSpawnTroop);

            var gameobj = Instantiate(_troopsToBeSpawnedList[0], transform.position, direction);

            _troopsToBeSpawnedList.RemoveAt(0);
            
            if(_troopsToBeSpawnedList.Count <= 0) {
                var checkIfTheresTroopLeft = gameobj.AddComponent<CheckIfTheresTroopLeft>();
            
                checkIfTheresTroopLeft.TheresNoTroopLeft = GetComponent<CheckIfTheresTroopLeft>().TheresNoTroopLeft;
            }
            
            
            if(_towerTransform != null) {
                gameobj.GetComponent<MoveToTarget>()?.SetTarget(_towerTransform);
            }
            
        }
    }

    private bool ExistsTroopsInQueueToBeSpawned()
    {
        return _troopsToBeSpawnedList.Count > 0;
    }

    public List<GameObject> TroopsToBeSpawnedList {
        get => _troopsToBeSpawnedList;
        set => _troopsToBeSpawnedList = value;
    }
}