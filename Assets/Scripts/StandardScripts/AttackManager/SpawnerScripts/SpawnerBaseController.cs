using System.Collections.Generic;
using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class SpawnerBaseController : BaseController{
        private AttackTroopsSpawner _northSpawner;
        private AttackTroopsSpawner _southSpawner;
        private AttackTroopsSpawner _eastSpawner;
        private AttackTroopsSpawner _westSpawner;


        public void InitializeSpawners() {
            CreateTroopGroup();
            _northSpawner.TroopsToBeSpawnedList = ConvertPrefabNameToGameObj(_troopListGroup.NorthList);
            _southSpawner.TroopsToBeSpawnedList = ConvertPrefabNameToGameObj(_troopListGroup.SouthList);
            _eastSpawner.TroopsToBeSpawnedList = ConvertPrefabNameToGameObj(_troopListGroup.EastList);
            _westSpawner.TroopsToBeSpawnedList = ConvertPrefabNameToGameObj(_troopListGroup.WestList);
        }

        private List<GameObject> ConvertPrefabNameToGameObj(List<string> list) {
            List<GameObject> listToReturn = new List<GameObject>();
            foreach (var gameobjName in list) {
                listToReturn.Add(Resources.Load<GameObject>($@"Prefabs/Troops/Attackers/{gameobjName}"));
            }

            return listToReturn;
        }
        
        protected override void CreateTroopGroup() {
            _troopListGroup = JsonUtility.FromJson<TroopListGroup>(_db.GetJsonStringFromDataBase());
        }
        
        public SpawnerBaseController(IBancoDeDados db, AttackTroopsSpawner northSpawner, AttackTroopsSpawner southSpawner, AttackTroopsSpawner eastSpawner, AttackTroopsSpawner westSpawner) {
            _db = db;
            _northSpawner = northSpawner;
            _southSpawner = southSpawner;
            _eastSpawner = eastSpawner;
            _westSpawner = westSpawner;
        }
    }
}