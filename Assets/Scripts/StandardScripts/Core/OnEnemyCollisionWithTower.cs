using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyCollisionWithTower : MonoBehaviour
{
    private PlaySound _playSound;

    void OnEnable()
    {
        Tower.OnEnemyAndTowerCollision += TowerCollision;
    }

    void OnDisable()
    {
        Tower.OnEnemyAndTowerCollision -= TowerCollision;
    }

    void TowerCollision()
    {
        _playSound.Play();
    }

    void Start()
    {
        _playSound = GetComponent<PlaySound>();
    }
}
