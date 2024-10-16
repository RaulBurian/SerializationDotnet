using System.Text.Json;

namespace SerializationJourney._10___STJ_Source_Generation;

public static class SourceGenerationStj
{
    public static void SourceGenerationStjExamples()
    {
        var str = """
                  {
                      "Id": "d271e035-5b8b-4d52-bf7b-5f0e1ad8beaa",
                      "Name": "Sample Name",
                      "EffectiveDate": "2024-10-14T12:00:00",
                      "Grade": 5,
                      "AList": [
                          "Item1",
                          "Item2",
                          "Item3"
                      ],
                      "ComplexObject": {
                          "OneProp": "Value1",
                          "AnotherProp": "Value2"
                      }
                  }
                  """;
        var demoEntry = JsonSerializer.Deserialize<DemoEntry>(str, DemoEntryContext.Default.DemoEntry);

        Console.WriteLine("Regular STJ");
        Console.WriteLine(JsonSerializer.Serialize(demoEntry));

        Console.WriteLine("----------------------------");

        Console.WriteLine("Source Gen STJ");
        Console.WriteLine(JsonSerializer.Serialize(demoEntry, DemoEntryContext.Default.DemoEntry));
    }
}
