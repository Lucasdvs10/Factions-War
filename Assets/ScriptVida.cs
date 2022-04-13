using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVida : MonoBehaviour
{
    [SerializeField] private float vidaDaTropa;
    [SerializeField] private float dano;
    public float GetVidaDaTropa() => vidaDaTropa;
    
    public float AplicarDano(float dano){
        float novaVida = GetVidaDaTropa() - dano; 
        vidaDaTropa = novaVida; 
        return (vidaDaTropa); 
    }
    
    void Start()
    {   
        Debug.Log(GetVidaDaTropa());
        Debug.Log(AplicarDano(dano));
    }
}
