using System.Collections.Generic;
using UnityEngine;

namespace StandardScripts{
    public class ActivateAndDeactivateGameObjs : MonoBehaviour{
        [SerializeField] private List<GameObject> _gameObjectsList;

        public void DeactivateGameObjs() {
            foreach (var obj in _gameObjectsList) {
                obj.SetActive(false);
            }
        }
        
        public void ActivateGameObjs() {
            foreach (var obj in _gameObjectsList) {
                obj.SetActive(true);
            }
        }  
    }
}