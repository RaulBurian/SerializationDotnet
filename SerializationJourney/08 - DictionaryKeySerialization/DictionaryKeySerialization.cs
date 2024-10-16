using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationJourney._08___DictionaryKeySerialization;

public class DictionaryKeySerialization
{
    public static void DictionaryKeySerializationExamples()
    {
        var obj = new DemoDict
        {
            Dict = new Dictionary<string, string>
            {
                { "A", "Value" },
                { "b", "Value" },
                { "ABCD", "Value" },
                { "abcd", "Value" },
                { "A_BCD", "Value" },
                { "A-BCD", "Value" },
                { "AB-CD", "Value" },
                { "AB_CD", "Value" }
            }
        };

        Console.WriteLine("Newtonsoft");
        Console.WriteLine(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { Formatting = Formatting.Indented }));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));

        Console.WriteLine("----------------------------");
    }
}
