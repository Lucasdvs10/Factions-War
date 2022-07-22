using System.IO;
using AttackManager;
using UnityEngine;
using Application = UnityEngine.WSA.Application;

namespace StandardScripts.AttackManager {
    public class SetupFactory : IBancoDeDados{
        private string _folderPath;

        public int GetLastFileIndex() {
            return GetAllFiles().Length;
        }
        
        public int GetNextFileIndex() {
            return GetLastFileIndex() + 1;
        }

        private string[] GetAllFiles() => Directory.GetFiles(_folderPath, "*.json");

        public void SendJsonStringToDataBase(string jsonString) {
            File.WriteAllText($@"{_folderPath}\{GetNextFileIndex()}.json",jsonString);
        }

        public string GetJsonStringFromDataBase() {
            return File.ReadAllText($@"{_folderPath}/{GetLastFileIndex()}.json");
        }
        
        public void SetFolderPath(string path) => _folderPath = path;
        public string GetFolderPath() => _folderPath;

        public SetupFactory(string folderPath) {
            _folderPath = folderPath;
        }
    }
}