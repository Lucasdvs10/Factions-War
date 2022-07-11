using System;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private float _towerHealth;
    
    public static event Action<float> OnTowerDamageTriggered;
    public static event Action OnZeroTowerHealth;
    public float GetTowerHealth() => _towerHealth;
    
    
    public float ApplyDamage(float damage) {
        OnTowerDamageTriggered?.Invoke(damage);
        _towerHealth -= damage;
        if (_towerHealth <= 0)
        {
            OnZeroTowerHealth?.Invoke();
        }
        return _towerHealth;
    }
}