using UnityEngine;

namespace AttackManager{
    public class SpawnerManager : Manager{
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerNorth;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerSouth;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerEast;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerWest;
        
        
        public void InjectListsInSpawners() {
            _attackTroopsSpawnerNorth.TroopsToBeSpawned = _troopListGroup.NorthList;
            _attackTroopsSpawnerSouth.TroopsToBeSpawned = _troopListGroup.SouthList;
            _attackTroopsSpawnerEast.TroopsToBeSpawned = _troopListGroup.EastList;
            _attackTroopsSpawnerWest.TroopsToBeSpawned = _troopListGroup.WestList;
        }
    }
}