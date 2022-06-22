using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static event Action OnEnemyAndTowerCollision;

    private TowerHealth _towerHealth;

    [SerializeField] private string _enemyTag;

    [SerializeField]
    private float _damageOnCollision;

    private void Start()
    {
        _towerHealth = GetComponent<TowerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        if (enemyCollider.gameObject.CompareTag(_enemyTag)) //INSERT ENEMY TAG HERE
        {
            OnEnemyAndTowerCollision?.Invoke();
            Destroy(enemyCollider.gameObject);
            _towerHealth.ApplyDamage(_damageOnCollision);
        }
    }
}
