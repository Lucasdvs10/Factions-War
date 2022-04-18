using System;
using UnityEngine;

public class ScriptVida : MonoBehaviour
{
    [SerializeField] private float vidaDaTropa;
    
    public static event Action<float> OnDanoAcionado;
    public static event Action OnVidaZerada;
    public float GetVidaDaTropa() => vidaDaTropa;
    
    
    public float AplicarDano(float dano) {
        OnDanoAcionado?.Invoke(dano);
        vidaDaTropa -= dano;
        if (vidaDaTropa <= 0)
        {
            OnVidaZerada?.Invoke();
        }
        return vidaDaTropa;
    }
}