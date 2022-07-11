using UnityEngine;

namespace AttackSetupPanel{
    public class ObjectHandler : MonoBehaviour{
        [SerializeField] private GameObject _troopPrefab;

        public GameObject GetTroopPrefab() => _troopPrefab;
    }
}