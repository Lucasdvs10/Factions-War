using UnityEngine;

namespace AttackManager{
    public class SpawnerManager : Manager{
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerNorth;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerSouth;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerEast;
        [SerializeField] private AttackTroopsSpawner _attackTroopsSpawnerWest;


        private void Awake() {
            _db = new TestDataBase();
        }

        private void Start() {
            StartRound();
        }

        public void StartRound() {
            GetTroopFromJson();
            InjectListsInSpawners();
            StartAllTroopsSpawners();
        }

        private void StartAllTroopsSpawners() {
            _attackTroopsSpawnerNorth.SpawnTroopsInSeconds(2f);
            _attackTroopsSpawnerSouth.SpawnTroopsInSeconds(2f);
            _attackTroopsSpawnerEast.SpawnTroopsInSeconds(2f);
            _attackTroopsSpawnerWest.SpawnTroopsInSeconds(2f);
        }

        private void InjectListsInSpawners() {
            _attackTroopsSpawnerNorth.TroopsToBeSpawnedList = _troopListGroup.NorthList;
            _attackTroopsSpawnerSouth.TroopsToBeSpawnedList = _troopListGroup.SouthList;
            _attackTroopsSpawnerEast.TroopsToBeSpawnedList = _troopListGroup.EastList;
            _attackTroopsSpawnerWest.TroopsToBeSpawnedList = _troopListGroup.WestList;
        }
    }
}