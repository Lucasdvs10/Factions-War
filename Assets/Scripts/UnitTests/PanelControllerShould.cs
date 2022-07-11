using System;
using System.Collections.Generic;
using AttackManager;
using NSubstitute;
using NUnit.Framework;
using StandardScripts.AttackManager;
using UnityEngine;

namespace DefaultNamespace{
    public class PanelControllerShould{


        [Test]
        public void Send_Empty_Troop_List_To_DB() {
            List<GameObject> troopList = new List<GameObject>();
            var db = Substitute.For<IBancoDeDados>();
            
            
            PanelController panelController = new PanelController(db,troopList, troopList, troopList, troopList);
            var resultado = panelController.SendToDataBase();
            
            Assert.AreEqual(JsonUtility.ToJson(new TroopListGroup(troopList, troopList, troopList, troopList), true), resultado);

        }
        
        [Test]
        public void Send_NonEmpty_Troop_List_To_DB() {
            List<GameObject> troopList = new List<GameObject>(){new GameObject()};
            var db = Substitute.For<IBancoDeDados>();
            
            
            PanelController panelController = new PanelController(db,troopList, troopList, troopList, troopList);
            var resultado = panelController.SendToDataBase();
            
            Assert.AreEqual(JsonUtility.ToJson(new TroopListGroup(troopList, troopList, troopList, troopList), true), resultado);
        }
        
        
    }
}