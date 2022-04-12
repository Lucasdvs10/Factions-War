using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVida : MonoBehaviour
{
    public float VidaDaTropa;
    public float dano;
    public float getVidaDaTropa(){
        return (this.VidaDaTropa);
    }
    public float aplicarDano(float dano){
        float novaVida = getVidaDaTropa() - dano;
        this.VidaDaTropa = novaVida;
        return (VidaDaTropa);
    }
    
    void Start()
    {   
        Debug.Log(getVidaDaTropa());
        Debug.Log(aplicarDano(dano));
    }

    
    void Update()
    {
        
    }
}
