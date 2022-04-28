using System;
using UnityEngine;

public class TowerLife : MonoBehaviour
{
    [SerializeField] private float _towerLife;
    
    public static event Action<float> OnTowerDamageTriggered;
    public static event Action OnTowerZeroHealth;
    public float GetTowerLife() => _towerLife;
    
    
    public float ApplyDamage(float damage) {
        OnTowerDamageTriggered?.Invoke(damage);
        _towerLife -= damage;
        if (_towerLife <= 0)
        {
            OnTowerZeroHealth?.Invoke();
        }
        return _towerLife;
    }
}