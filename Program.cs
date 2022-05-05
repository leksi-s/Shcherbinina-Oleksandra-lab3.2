using Newtonsoft.Json;

Dictionary[] dictionaries =
{
    new Dictionary("key1", "value1"),
    new Dictionary("key1","value2"),
    new Dictionary("key2","value3"),
    new Dictionary("key3", "value1")
};

var values = from dictionary in dictionaries
             group dictionary by dictionary.Value into d
             select new
             {
                 Name = d.Key,
                 Group = from p in d select p
             };
Console.WriteLine("однакові ключі з пари ключ-значення:");
foreach (var value in values)
{
    Console.WriteLine($"{value.Name}:");
    foreach (var gr in value.Group)
    {
        Console.WriteLine(gr.Key);
    }
    Console.WriteLine(); // для разделения компаний
}

var keys = from dictionary in dictionaries
          group dictionary by dictionary.Key into d
          select new
          { Name = d.Key, Group = from p in d select p };

Console.WriteLine("однакові значення з пари ключ-значення:");
foreach (var key in keys)
{
    Console.WriteLine($"{key.Name}:");
    foreach(var gr in key.Group)
    { 
        Console.WriteLine(gr.Value); 
    }
    Console.WriteLine();
}

Dictionary dc = new Dictionary();
dc.Serealize(dictionaries);
class Dictionary
{
    public string Key { get; set; }
    public string Value { get; set; }

    public Dictionary(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public Dictionary()
    {
    }

    public void Serealize(Dictionary[] dictionaries1)
    {
        string jsonString = JsonConvert.SerializeObject(dictionaries1);
        Console.WriteLine(jsonString);
        File.WriteAllText("C:/Users/Admin/source/repos/лаба3.2/лаба3.2/tojson.json", jsonString);
    }
}


