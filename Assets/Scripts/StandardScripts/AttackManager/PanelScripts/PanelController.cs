using System.Collections.Generic;
using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class PanelController : BaseController{
       
        private List<GameObject> _northList;
        private List<GameObject> _southList;
        private List<GameObject> _eastList;
        private List<GameObject> _westList;
        
        public string SendToDataBase() {
            var jsonHandler = new JsonHandler();

            CreateTroopGroup();
            var content = jsonHandler.CreateJsonOfObj(_troopListGroup);
            _db.SendJsonStringToDataBase(content);
            
            Debug.Log("Enviei :D");
            return content;
        }

        protected override void CreateTroopGroup() {
            _troopListGroup = new TroopListGroup(_northList, _southList, _eastList, _westList);
        }
        
        public PanelController(IBancoDeDados db, List<GameObject> northList, List<GameObject> southList, List<GameObject> eastList, List<GameObject> westList) {
            _db = db;
            _northList = northList;
            _southList = southList;
            _eastList = eastList;
            _westList = westList;
        }
    }
}