using System.IO;
using UnityEngine;

namespace AttackManager{
    public class TestDataBase : IBancoDeDados{
        public string _jsonPath = Application.dataPath + @"\Teste.json";

        public void SendJsonStringToDataBase(string jsonString) {
            File.WriteAllText(_jsonPath, jsonString);
        }

        public string GetJsonStringFromDataBase() {
            var jsonString = File.ReadAllText(_jsonPath);
            return jsonString;
        }
    }
}