using System.Collections.Generic;
using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class PanelController : BaseController{
       
        private List<string> _northList;
        private List<string> _southList;
        private List<string> _eastList;
        private List<string> _westList;
        
        public string SendToDataBase() {
            var jsonHandler = new JsonHandler();

            CreateTroopGroup();
            var content = JsonUtility.ToJson(_troopListGroup, true);
            _db.SendJsonStringToDataBase(content);
            
            Debug.Log("Enviei :D");
            return content;
        }

        protected override void CreateTroopGroup() {
            _troopListGroup = new TroopListGroup(_northList, _southList, _eastList, _westList);
        }

        public PanelController(IBancoDeDados db,List<string> northList, List<string> southList, List<string> eastList, List<string> westList) {
            _db = db;
            _northList = northList;
            _southList = southList;
            _eastList = eastList;
            _westList = westList;
        }
    }
}