using System.IO;
using AttackManager;
using UnityEngine;

namespace StandardScripts.AttackManager {
    public class SetupFactory : IBancoDeDados{
        private string _folderPath;
        private int _currentIndex = 0;

        public int GetLastFileIndex() {
            return GetAllFiles().Length;
        }
        
        public int GetNextFileIndex() {
            return GetLastFileIndex() + 1;
        }

        public int GetCurrentIndex() => _currentIndex;
        
        public void AddOneIndex() => _currentIndex++;

        private string[] GetAllFiles() => Directory.GetFiles(_folderPath, "*.json");

        public void SendJsonStringToDataBase(string jsonString) {
            File.WriteAllText($@"{_folderPath}/{GetNextFileIndex()}.json",jsonString);
        }

        public string GetJsonStringFromDataBase() {
            var filePath = $@"{_folderPath}/{GetCurrentIndex()}.json";
            
            if(File.Exists($@"{_folderPath}/{GetCurrentIndex()}.json"))
                return File.ReadAllText(filePath);
            
            //Lidando com o que acontece se chegar no último arquivo
            
            Debug.Log("Esse arquivo nao ecxiste, vou enviar o arquivo anterior");
            return File.ReadAllText($@"{_folderPath}/{GetLastFileIndex()}.json");
        }
        
        public void SetFolderPath(string path) => _folderPath = path;
        public string GetFolderPath() => _folderPath;

        public SetupFactory(string folderPath) {
            _folderPath = folderPath;
        }
    }
}