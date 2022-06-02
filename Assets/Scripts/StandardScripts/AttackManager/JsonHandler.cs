using System.IO;
using UnityEngine;

namespace AttackManager{
    public class JsonHandler{


        public string CreateJsonOfObj<T>(T obj) {
            var stringResult = JsonUtility.ToJson(obj, true);
            return stringResult;
        }

        public T GetObjectFromJson<T>(string content) {
            return JsonUtility.FromJson<T>(content);
        }

        public string GetJsonStringFromPath(string path) {
            if(File.Exists(path))
                return File.ReadAllText(path);
            return null;
        }


    }
}