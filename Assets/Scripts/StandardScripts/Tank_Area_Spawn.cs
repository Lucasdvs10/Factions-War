using System;
using StandardScripts;
using UnityEngine;

public class Tank_Area_Spawn : MonoBehaviour, IEventEmitter{
   [SerializeField] private CurrentMoney _currentMoney;
   [SerializeField] private GameObject _prefabToInstantiate;
   [SerializeField] private float offSet = 12f;
   [SerializeField] private float _angle;
   private int _troopCost;
    
   public event Action CharacterCreationEvent;

   public void ActivateAreaObj() {
        gameObject.SetActive(true);
    }
    
   public void DeactivateAreaObj() {
        gameObject.SetActive(false);
    }
    
   public void SetTroopCost(int cost) {
        _troopCost = cost;
    }
    
   private void OnMouseDown() {
        if (_currentMoney.GetCurrentMoney >= _troopCost) {
            Instantiate(_prefabToInstantiate, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.Euler(0,0,_angle));
            _currentMoney.UpdateMoney(-15);
            CharacterCreationEvent?.Invoke();
        }
   }
}
