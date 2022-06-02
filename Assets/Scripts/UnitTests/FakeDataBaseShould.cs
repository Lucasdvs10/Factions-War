using System.IO;
using AttackManager;
using NSubstitute;
using NUnit.Framework;

public class FakeDataBaseShould
{
    // A Test behaves as an ordinary method
    [Test]
    public void FakeDataBaseShould_Create_File_At_Path() {
        TestDataBase db = new TestDataBase();

        File.Delete(db.Path);
        db.SendJson("oioioi");
        FileAssert.Exists(db.Path);
    }
    
    [Test]
    public void FakeDataBaseShould_Get_String_From_Json() {
        TestDataBase db = new TestDataBase();
        var stringJson = db.GetJsonString();
        Assert.IsInstanceOf<string>(stringJson);
        
    }
}
