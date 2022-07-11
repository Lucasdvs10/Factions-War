using AttackManager;
using NUnit.Framework;
using UnityEngine;

namespace DefaultNamespace{
    public class JsonHandler_Should{
        private JsonHandler _jsonHandler;

        [SetUp]
        public void Initialize_Tests() {
            _jsonHandler = new JsonHandler();
        }
        
        [Test]
        public void Transform_Integer_In_String() {
            int kappa = 42;
            string resultado = _jsonHandler.CreateJsonOfObj(kappa);
            Assert.IsInstanceOf<string>(resultado);
        }
        
        [Test]
        public void Transform_troopGroup_In_Json_String() {
            var troopGroup = new TroopListGroup(null, null, null, null);
            var resultado = _jsonHandler.CreateJsonOfObj(troopGroup);
            Assert.AreEqual( JsonUtility.ToJson(troopGroup, true), resultado);
        }
        
        [Test]
        public void Get_troopGroup_From_Json_String() {
            string jsonString = "{\"NorthList\":[],\"SouthList\":[],\"EastList\":[],\"WestList\":[]}";
            var resultado = _jsonHandler.GetObjectFromJson<TroopListGroup>(jsonString);
            Assert.IsInstanceOf<TroopListGroup>(resultado);
        }
        
    }
}