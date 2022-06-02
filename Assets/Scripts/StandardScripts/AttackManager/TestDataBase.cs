using System.IO;

namespace AttackManager{
    public class TestDataBase : IBancoDeDados{
        public string _jsonPath = @"C:\Users\lucas\Desktop\Projetos Atuais\Factions-War\Assets\Teste.json";

        public void SendJsonStringToDataBase(string jsonString) {
            File.WriteAllText(_jsonPath, jsonString);
        }

        public string GetJsonStringFromDataBase() {
            var jsonString = File.ReadAllText(_jsonPath);
            return jsonString;
        }
    }
}