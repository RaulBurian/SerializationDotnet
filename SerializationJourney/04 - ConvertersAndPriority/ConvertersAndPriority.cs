using Newtonsoft.Json;

namespace SerializationJourney._04___ConvertersAndPriority;

public static class ConvertersAndPriority
{
    public const string EntryV1 = "{}";

    public static void ConvertersAndPriorityExamples()
    {
        var objNewtonsoft = JsonConvert.DeserializeObject<DemoConverters>(EntryV1);

        var objSystemText = System.Text.Json.JsonSerializer.Deserialize<DemoConverters>(EntryV1);

        Console.WriteLine("Newtonsoft");
        Console.WriteLine(JsonConvert.SerializeObject(objNewtonsoft));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(objSystemText));

        Console.WriteLine("----------------------------");
    }
}
