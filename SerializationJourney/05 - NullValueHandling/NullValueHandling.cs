using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SerializationJourney._05___NullValueHandling;

public static class NullValueHandling
{
    public const string EntryV1 = """
                                  {
                                      "Name": "Sample Name",
                                      "Value": 5
                                  }
                                  """;

    public const string EntryV2 = """
                                  {
                                      "Name": "Sample Name"
                                  }
                                  """;

    public const string EntryV3 = """
                                  {
                                      "Name": "Sample Name",
                                      "Value": null
                                  }
                                  """;

    public static void NullValueHandlingExample()
    {
        var objNewtonsoft = JsonConvert.DeserializeObject<DemoNull>(EntryV1);

        var objSystemTextJson = System.Text.Json.JsonSerializer.Deserialize<DemoNull>(EntryV3);

        Console.WriteLine("Newtonsoft");
        Console.WriteLine(JsonConvert.SerializeObject(objNewtonsoft));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(objSystemTextJson));

        Console.WriteLine("----------------------------");
    }
}
