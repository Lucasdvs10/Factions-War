using System;
using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class SpawnerControllerMono : MonoBehaviour{
        [SerializeField] private AttackTroopsSpawner _northSpawner;
        [SerializeField] private AttackTroopsSpawner _southSpawner;
        [SerializeField] private AttackTroopsSpawner _eastSpawner;
        [SerializeField] private AttackTroopsSpawner _westSpawner;
        private SetupFactory _bancoDeDados;
        
        
        private SpawnerBaseController _spawnerBaseController;

        private void Awake() {
            _bancoDeDados = new SetupFactory(Application.dataPath + @"\SetupJsons");
            _spawnerBaseController = new SpawnerBaseController(_bancoDeDados,_northSpawner, _southSpawner, _eastSpawner, _westSpawner);
        }

        public void StartRound() {
            _bancoDeDados.AddOneIndex();

            _spawnerBaseController.InitializeSpawners();
            
            _northSpawner.SpawnTroopsInSeconds(3f);
            _southSpawner.SpawnTroopsInSeconds(3f);
            _eastSpawner.SpawnTroopsInSeconds(3f);
            _westSpawner.SpawnTroopsInSeconds(3f);
            
        }
        
    }
}