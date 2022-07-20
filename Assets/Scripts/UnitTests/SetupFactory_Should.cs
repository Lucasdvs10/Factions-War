using NUnit.Framework;
using StandardScripts.AttackManager;

namespace DefaultNamespace {
    public class SetupFactory_Should {
        private SetupFactory _setupFactory;
        
        [SetUp]
        public void SetupAllTests() {
            _setupFactory = new SetupFactory();
        }
        
        [Test]
        public void Return_A_Number_One_Bigger_Than_Last_File() {
            int lastIndex = _setupFactory.GetLastFileIndex();
            int nextFileIndex = _setupFactory.GetNextFileIndex();
            
            Assert.AreEqual(lastIndex+1, nextFileIndex);
        }
    }
}