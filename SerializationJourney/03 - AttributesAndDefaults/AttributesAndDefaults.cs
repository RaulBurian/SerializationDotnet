using Newtonsoft.Json;

namespace SerializationJourney._03___AttributesAndDefaults;

public static class AttributesAndDefaults
{
    public const string EntryV1 = """
                                  {
                                      "Name": "ExampleName",
                                      "Color": "Blue",
                                      "Value": 42
                                  }
                                  """;

    public const string EntryV2 = """
                                  {
                                      "name": "ExampleName",
                                      "color": "Blue",
                                      "value": 42
                                  }
                                  """;

    public const string EntryV3 = """
                                  {
                                      "thisName": "ExampleName",
                                      "someColor": "Blue",
                                      "actualValue": 42
                                  }
                                  """;

    public static void AttributesAndDefaultsExamples()
    {
        var objNewtonsoft = JsonConvert.DeserializeObject<DemoAttributesAndDefaults>(EntryV1);

        var objSystemText = System.Text.Json.JsonSerializer.Deserialize<DemoAttributesAndDefaults>(EntryV1);

        Console.WriteLine("Newtonsoft");
        Console.WriteLine(JsonConvert.SerializeObject(objNewtonsoft));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(objSystemText));

        Console.WriteLine("----------------------------");
    }
}
