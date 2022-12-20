using System.Text.Json;
using tasks_testing.UserModel;
using YamlDotNet.Serialization;

namespace tasks_testing;

public  class Initializer
{
    public User[] DeserializerJson(string path)
    {
        string jsonString = File.ReadAllText(path);
        User[] jsonData = JsonSerializer.Deserialize<User[]>(jsonString);
        
        return jsonData;
    }

    public User[] DeserializationYaml(string path)
    {
        var deserializer = new DeserializerBuilder().Build();
        User[] yamlData = deserializer.Deserialize<User[]>( new StreamReader(path));

        return yamlData;
    }
}