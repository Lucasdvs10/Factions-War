using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private PlaySound _playSound;

    void OnEnable()
    {
        LifeScript.OnZeroLife += Death;
    }

    void OnDisable()
    {
        LifeScript.OnZeroLife -= Death;
    }

    void Death()
    {
        _playSound.Play();
    }

    void Start()
    {
        _playSound = GetComponent<PlaySound>();
    }
}
