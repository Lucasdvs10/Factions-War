using System;
using UnityEngine;
using UnityEngine.Events;

public class TowerHealth : MonoBehaviour
{
    public UnityEvent TowerOnDeath;
    public HealthBar healthBar;
    public float maxHealth;
    [SerializeField] private float _towerHealth;
    
    public static event Action<float> OnTowerDamageTriggered;
    public static event Action OnZeroTowerHealth;
    public float GetTowerHealth() => _towerHealth;
    
    public void Start(){
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(_towerHealth);
    }
    
    public float ApplyDamage(float damage) {
        OnTowerDamageTriggered?.Invoke(damage);
        _towerHealth -= damage;
        healthBar.SetHealth(_towerHealth);
        if (_towerHealth <= 0)
        {
            OnZeroTowerHealth?.Invoke();
            TowerOnDeath?.Invoke();
        }
        return _towerHealth;
    }
}