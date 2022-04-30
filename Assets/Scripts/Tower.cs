using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static event Action OnEnemyAndTowerCollision;

    private TowerHealth _towerHealth;

    [SerializeField]
    private float _damageOnCollision;

    private void Start()
    {
        _towerHealth = GetComponent<TowerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        if (enemyCollider.gameObject.CompareTag("")) //INSERT ENEMY TAG HERE
        {
            OnEnemyAndTowerCollision?.Invoke();
            Destroy(enemyCollider.gameObject);
            _towerHealth.ApplyDamage(_damageOnCollision);
        }
    }
}
