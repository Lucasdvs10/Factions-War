using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class SpawnerControllerMono : MonoBehaviour{
        [SerializeField] private AttackTroopsSpawner _northSpawner;
        [SerializeField] private AttackTroopsSpawner _southSpawner;
        [SerializeField] private AttackTroopsSpawner _eastSpawner;
        [SerializeField] private AttackTroopsSpawner _westSpawner;
        
        private SpawnerBaseController _spawnerBaseController;

        public void StartRound() {
            _spawnerBaseController = new SpawnerBaseController(new SetupFactory(),_northSpawner, _southSpawner, _eastSpawner, _westSpawner);
            
            _spawnerBaseController.InitializeSpawners();
            
            _northSpawner.SpawnTroopsInSeconds(3f);
            _southSpawner.SpawnTroopsInSeconds(3f);
            _eastSpawner.SpawnTroopsInSeconds(3f);
            _westSpawner.SpawnTroopsInSeconds(3f);
            
        }
        
    }
}