using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeTropasAtacantes : MonoBehaviour
{
    private Queue<GameObject> _tropasQueSeramSpawnadas;
    public GameObject[] vetorDeInicializacaoDaFilaDeTropas;
    void Start()
    {
        this._tropasQueSeramSpawnadas = new Queue<GameObject>(vetorDeInicializacaoDaFilaDeTropas);
        SpawnarTropaNaFilaEmSegundos(3.0f);
    }



    public void SpawnarTropaNaFilaEmSegundos(float segundosParaSpawnarTropa)
    {
        StartCoroutine(spawnarTropaNaFilaEmSegundosCorrotina(segundosParaSpawnarTropa));
    }

    public void AdicionarTropaNaFilaParaSerSpawnadas(GameObject tropa){
        _tropasQueSeramSpawnadas.Enqueue(tropa);
    }

    private IEnumerator spawnarTropaNaFilaEmSegundosCorrotina(float segundosParaSpawnarTropa)
    {
        while (ExistemTropasQueSeramSpawnadas())
        {
            yield return new WaitForSeconds(segundosParaSpawnarTropa);
            Instantiate(_tropasQueSeramSpawnadas.Dequeue());
        }
    }

    private bool ExistemTropasQueSeramSpawnadas()
    {
        return _tropasQueSeramSpawnadas.Count > 0;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 1.5f);
    }
}
