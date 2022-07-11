using System.Collections.Generic;
using AttackManager;
using NSubstitute;
using NUnit.Framework;
using StandardScripts.AttackManager;
using UnityEngine;

namespace DefaultNamespace{
    public class SpawnerControllerShould{
        [Test]
        public void Setup_Spawners_List() {
            GameObject gameObject = new GameObject();
            AttackTroopsSpawner attackTroopsSpawner = gameObject.AddComponent<AttackTroopsSpawner>();
            List<GameObject> list = new List<GameObject>(){new GameObject()};
            TroopListGroup troopListGroup = new TroopListGroup(list, list, list, list);
            
            
            var db = Substitute.For<IBancoDeDados>();
            db.GetJsonStringFromDataBase().Returns(JsonUtility.ToJson(troopListGroup));

            var controller = new SpawnerBaseController(db, attackTroopsSpawner, attackTroopsSpawner, attackTroopsSpawner,
                attackTroopsSpawner);
            
            controller.InitializeSpawners();
            Assert.AreEqual(troopListGroup.NorthList, attackTroopsSpawner.TroopsToBeSpawnedList);

        }
    }
}