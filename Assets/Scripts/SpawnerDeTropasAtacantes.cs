using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeTropasAtacantes : MonoBehaviour
{
    private Queue<GameObject> TropasQueSeramSpawnadas;
    public GameObject[] vetorDeInicializacaoDaFilaDeTropas;
    void Start()
    {
        this.TropasQueSeramSpawnadas = new Queue<GameObject>(vetorDeInicializacaoDaFilaDeTropas);
        spawnarTropaNaFilaEmSegundos(3.0f);
    }



    public void spawnarTropaNaFilaEmSegundos(float segundosParaSpawnarTropa)
    {
        StartCoroutine(spawnarTropaNaFilaEmSegundosCorrotina(segundosParaSpawnarTropa));
    }

    public void AdicionarTropaNaFilaParaSerSpawnadas(GameObject tropa){
        TropasQueSeramSpawnadas.Enqueue(tropa);
    }

    private IEnumerator spawnarTropaNaFilaEmSegundosCorrotina(float segundosParaSpawnarTropa)
    {
        while (ExistemTropasQueSeramSpawnadas())
        {
            yield return new WaitForSeconds(segundosParaSpawnarTropa);
            Instantiate(TropasQueSeramSpawnadas.Dequeue());
        }
    }

    private bool ExistemTropasQueSeramSpawnadas()
    {
        return TropasQueSeramSpawnadas.Count > 0;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 1.5f);
    }
}
