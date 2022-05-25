using System;
using System.Collections;
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

        private void Start() {
            StartCoroutine(Teste());
        }

        private IEnumerator Teste() {
            yield return new WaitForSeconds(10f);
            print("Enviei :D");
            CreateTroopsList();
            SendJsonStringToDB();
        }

        private void CreateTroopsList() { 
            _troopListGroup = new TroopListGroup(_attackSetupPanelNorth.ListPanel,_attackSetupPanelSouth.ListPanel, _attackSetupPanelEast.ListPanel, _attackSetupPanelWest.ListPanel);
        }
        
    }
}