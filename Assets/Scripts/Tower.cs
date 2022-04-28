using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static event Action OnEnemyAndTowerCollision;

    private TowerLife _towerLife;

    [SerializeField]
    private float _damageOnCollision;

    private void Start()
    {
        _towerLife = GetComponent<TowerLife>();
    }

    private void OnTriggerEnter2D(Collider2D colliderEnemy)
    {
        if (colliderEnemy.gameObject.CompareTag("")) //Insert enemy tag here
        {
            Destroy(colliderEnemy.gameObject);
            _towerLife.ApplyDamage(_damageOnCollision);
            OnEnemyAndTowerCollision?.Invoke();
        }
    }
}
