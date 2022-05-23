using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AttackManager{
    public class AttackManager : MonoBehaviour{
        private IBancoDeDados _bd;
        private string path = @"C:\Users\lucas\Desktop\Projetos Atuais\Factions-War\Assets\Teste.json";

        public void SendAttackToDB(QueueGroup group) {
            // criar um json com as tropas

            var conteudoJson = JsonUtility.ToJson(group, true);
            
            File.WriteAllText(path, conteudoJson);


            //enviá-lo pro banco
        }

        private void Start() {
            //
            // var fila = new List<GameObject>() { };
            //
            // fila.Add(transform.gameObject);
            //
            // var grupo = new QueueGroup(fila, fila, fila, fila);
            //
            // SendAttackToDB(grupo);

            var json = File.ReadAllText(path);
            
            var lista = JsonUtility.FromJson<QueueGroup>(json);
            
            
            print(lista.NorthList[0]);


        }
    }
}