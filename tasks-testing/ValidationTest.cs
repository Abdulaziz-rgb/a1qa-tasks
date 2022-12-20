namespace tasks_testing;

using System.Text.Json;
using NUnit.Framework;
using UserModel;
using YamlDotNet.Serialization;

[TestFixture]
public class ValidationTest
{
    
    private RegularUser _jsonData;
    private RegularUser _yamlData;

    [SetUp]
    public void Init()
    {
        string text = File.ReadAllText(@"C:\Users\abdulaziz\Desktop\L1. Test users files/regular_users.json");
        var _jsonData = JsonSerializer.Deserialize<RegularUser[]>(text);

        var deserializer = new DeserializerBuilder().Build();
        var _yamlData =
            deserializer.Deserialize<RegularUser[]>(
                new StreamReader(@"C:\Users\abdulaziz\Desktop\L1. Test users files/regular_users.yaml"));
    }
    // The task is not completed yet. I have opened PR so as to go with the next tasks.
    // Moreover, I am having difficulties in unit testing. Hope you will understand my situation, bro!
    [Test]   
    public void ValidateUserFilesTest()
    {
        
    }
}