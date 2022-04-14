using System;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class ScriptVida : MonoBehaviour
{
    [SerializeField] private float vidaDaTropa;
    public static event Action<float> OnDanoAcionado;
    public static event Action OnVidaZerada;
    private float dano = 5;
    public float AplicarDano(float dano)
    {
        OnDanoAcionado?.Invoke(dano);
        vidaDaTropa -= dano;
        return vidaDaTropa;
    }
    public float GetVidaDaTropa() => vidaDaTropa;

    public void teste() => Debug.Log("Apertou espaço");

    private void Start()
    {
        ScriptInimigo.OnDanoDado += teste;
    }

    void Update()
    {
        if (GetVidaDaTropa() == 0)
        {
            OnVidaZerada?.Invoke();
        }
    }
}
