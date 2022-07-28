using System;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    [SerializeField] private float _troopLife;
    
    public static event Action<float> OnDamageFired;
    public static event Action OnZeroLife;
    public float Get_troopLife() => _troopLife;

    public int KillReward = 10;
    
    
    public float ApplyDamage(float damage) {
        OnDamageFired?.Invoke(damage);
        _troopLife -= damage;
        if (_troopLife <= 0)
        {
            if(gameObject.tag == "Attackers")
            {
                AddMoney();
            }
            Destroy(transform.gameObject);
            OnZeroLife?.Invoke();
        }
        return _troopLife;
    }

    public GameObject[] MoneyUI;
    void AddMoney()
    {
        MoneyUI = GameObject.FindGameObjectsWithTag("MoneyUI");
        MoneyUI[0].GetComponent<CurrentMoney>().UpdateMoney(KillReward);
    }
}