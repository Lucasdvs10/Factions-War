using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInimigo : MonoBehaviour
{
    [SerializeField] private float dano;
    public static event Action OnDanoDado;

    public void GetKey()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnDanoDado?.Invoke();
        }
    }
    public void Comemorar()
    {
        Debug.Log("Ele morreu!");
    }
    void Start()
    {
        ScriptVida.OnVidaZerada += Comemorar;
        
    }
    
    void Update()
    {
        GetKey();
    }
}
