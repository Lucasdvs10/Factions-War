using System.Collections.Generic;
using AttackManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace StandardScripts.AttackManager{
    public class PanelControllerMono : MonoBehaviour{
        [SerializeField] private AttackPanelHandler _northPanel;
        [SerializeField] private AttackPanelHandler _southPanel;
        [FormerlySerializedAs("_EastPanel")] [SerializeField] private AttackPanelHandler _eastPanel;
        [SerializeField] private AttackPanelHandler _westPanel;

        private List<string> _northListTroopsNames = new List<string>();
        private List<string> _southListTroopsNames = new List<string>();
        private List<string> _eastListTroopsNames = new List<string>();
        private List<string> _westListTroopsNames = new List<string>();

        private PanelController _panelController;
        
        public void InitializeAndSendToDataBase() {
            InitializePanelController();
            ConvertPrefabsToString();
            print(_panelController.SendToDataBase());
        }

        private void ConvertPrefabsToString() {
            foreach (var prefab in _northPanel.ListPanel) {
                _northListTroopsNames.Add(prefab.name);
            }
            
            foreach (var prefab in _southPanel.ListPanel) {
                _southListTroopsNames.Add(prefab.name);
            }
            
            foreach (var prefab in _eastPanel.ListPanel) {
                _eastListTroopsNames.Add(prefab.name);
            }
            
            foreach (var prefab in _westPanel.ListPanel) {
                _westListTroopsNames.Add(prefab.name);
            }
        }
        
        

        private void InitializePanelController() {
            _panelController = new PanelController(new SetupFactory(Application.dataPath + @"\SetupJsons"), _northListTroopsNames, _southListTroopsNames,
                _eastListTroopsNames, _westListTroopsNames);
        }
    }
}