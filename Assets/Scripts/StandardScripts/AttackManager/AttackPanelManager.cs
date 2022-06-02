using UnityEngine;

namespace AttackManager{
    public class AttackPanelManager : Manager{
        [SerializeField] private AttackPanelHandler attackPanelHandlerNorth;
        [SerializeField] private AttackPanelHandler attackPanelHandlerSouth;
        [SerializeField] private AttackPanelHandler attackPanelHandlerEast;
        [SerializeField] private AttackPanelHandler attackPanelHandlerWest;


        private void Awake() {
            _db = new TestDataBase();
        }

        public void SendAttackToDB() {
            CreateTroopsList();
            SendJsonStringToDB();
            print("Enviei :D");
        }

        private void CreateTroopsList() { 
            _troopListGroup = new TroopListGroup(attackPanelHandlerNorth.ListPanel,attackPanelHandlerSouth.ListPanel, attackPanelHandlerEast.ListPanel, attackPanelHandlerWest.ListPanel);
        }
        
    }
}