namespace tasks_testing;

using System.Text.Json;
using NUnit.Framework;
using UserModel;
using YamlDotNet.Serialization;

[TestFixture]
public class ValidationTest
{
    
    [Test]
    [TestCase(@"C:\Users\abdulaziz\Desktop\L1. Test users files/regular_users.json", @"C:\Users\abdulaziz\Desktop\L1. Test users files/regular_users.yaml")]
    [TestCase(@"C:\Users\abdulaziz\Desktop\L1. Test users files/admin_users.json", @"C:\Users\abdulaziz\Desktop\L1. Test users files/admin_users.json")]
    public void ValidateUserFilesTest(string jsonPath, string yamlPath)
    {
        Initializer Test = new Initializer();
        
        var usersJson = Test.DeserializerJson(jsonPath);
        var usersYaml = Test.DeserializationYaml(yamlPath);

        
        // 1 -> Validating that X.json contains array of users. User must have id and name
        Assert.IsInstanceOf<Array>(usersJson);

        foreach (var data in usersJson)
        {
            Assert.IsNotNull(data.id, "id should not be null");
            Assert.IsNotNull(data.name, "name should not be null");
        }

        // 2 -> Validating that X.yaml contains array of users. User must have id and name
        Assert.IsInstanceOf<Array>(usersYaml);
        
         foreach (var data in usersYaml)
        {
            Assert.IsNotNull(data.id, "id should not be null");
            Assert.IsNotNull(data.name, "name should not be null");
        }
         
         // 3 -> Validating that all users that listed in X.json are included in the list of users from X.yaml
        foreach (var jsonUser in usersJson)
        {
            Assert.IsTrue(usersYaml.Contains(jsonUser), "data does match each other");
        }  
    }
}