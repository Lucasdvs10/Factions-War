using UnityEngine;

namespace AttackManager{
    public class AttackPanelManager : Manager{
        [SerializeField] private AttackSetupPanel _attackSetupPanelNorth;
        [SerializeField] private AttackSetupPanel _attackSetupPanelSouth;
        [SerializeField] private AttackSetupPanel _attackSetupPanelEast;
        [SerializeField] private AttackSetupPanel _attackSetupPanelWest;


        private void Awake() {
            _db = new TestDataBase();
        }

        public void SendAttackToDB() {
            CreateTroopsList();
            SendJsonStringToDB();
            print("Enviei :D");
        }

        private void CreateTroopsList() { 
            _troopListGroup = new TroopListGroup(_attackSetupPanelNorth.ListPanel,_attackSetupPanelSouth.ListPanel, _attackSetupPanelEast.ListPanel, _attackSetupPanelWest.ListPanel);
        }
        
    }
}