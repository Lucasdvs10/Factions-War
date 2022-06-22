using System.IO;
using UnityEngine;

namespace AttackManager{
    public class TestDataBase : IBancoDeDados
    {
        private string _jsonPath = Application.dataPath + @"\Teste.json";

        public void SendJson(string jsonString) {
            File.WriteAllText(_jsonPath, jsonString);
        }

        public string GetJsonString() {
            var jsonString = File.ReadAllText(_jsonPath);
            return jsonString;
        }
    }
}