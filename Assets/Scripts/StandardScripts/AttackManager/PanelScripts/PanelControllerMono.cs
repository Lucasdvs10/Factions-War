using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager{
    public class PanelControllerMono : MonoBehaviour{
        [SerializeField] private AttackPanelHandler _northPanel;
        [SerializeField] private AttackPanelHandler _southPanel;
        [SerializeField] private AttackPanelHandler _EastPanel;
        [SerializeField] private AttackPanelHandler _westPanel;

        private PanelController _panelController;


        public void InitializeAndSendToDataBase() {
            InitializePanelController();
            _panelController.SendToDataBase();
        }

        private void InitializePanelController() {
            _panelController = new PanelController(new SetupFactory(), _northPanel.ListPanel, _southPanel.ListPanel,
                _EastPanel.ListPanel, _westPanel.ListPanel);
        }
    }
}