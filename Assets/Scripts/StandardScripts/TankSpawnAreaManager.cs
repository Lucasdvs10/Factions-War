using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StandardScripts{
    public class TankSpawnAreaManager : MonoBehaviour{
        private List<Tank_Area_Spawn> _tankAreaSpawnsList;

        private void Start() {
            _tankAreaSpawnsList = FindObjectsOfType<Tank_Area_Spawn>().ToList();
            DeactivateTankAreas();
        }

        public void ActivateTankAreas() {
            foreach (var tankAreaSpawn in _tankAreaSpawnsList) {
                tankAreaSpawn.gameObject.SetActive(true);
            }
        }
        
        public void DeactivateTankAreas() {
            foreach (var tankAreaSpawn in _tankAreaSpawnsList) {
                tankAreaSpawn.gameObject.SetActive(false);
            }
        }
        
        public void SetTroopCost(int cost) {
            foreach (var tankAreaSpawn in _tankAreaSpawnsList) {
                tankAreaSpawn.SetTroopCost(cost);
            }
        }
    }
}