using System.IO;

namespace AttackManager{
    public class TestDataBase : IBancoDeDados{
        private const string _jsonPath = @"C:\Users\lucas\Desktop\Projetos Atuais\Factions-War\Assets\Teste.json";

        public void SendJson(string jsonString) {
            File.WriteAllText(_jsonPath, jsonString);
        }

        public string GetJsonString() {
            var jsonString = File.ReadAllText(_jsonPath);
            return jsonString;
        }
    }
}