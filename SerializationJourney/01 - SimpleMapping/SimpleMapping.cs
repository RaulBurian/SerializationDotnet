using Newtonsoft.Json;

namespace SerializationJourney._01___SimpleMapping;

public static class SimpleMapping
{

    public const string EntryV1 = """
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

    public const string EntryV2 = """
                                  {
                                      "id": "d271e035-5b8b-4d52-bf7b-5f0e1ad8beaa",
                                      "name": "Sample Name",
                                      "effectiveDate": "2024-10-14T12:00:00",
                                      "grade": 5,
                                      "aList": [
                                          "Item1",
                                          "Item2",
                                          "Item3"
                                      ],
                                      "complexObject": {
                                          "oneProp": "Value1",
                                          "anotherProp": "Value2"
                                      }
                                  }
                                  """;

    public static void SimpleMappingExamples()
    {
        var objNewtonsoft = JsonConvert.DeserializeObject<DemoEntrySimpleMapping>(EntryV1);

        var objSystemText = System.Text.Json.JsonSerializer.Deserialize<DemoEntrySimpleMapping>(EntryV1);

        Console.WriteLine("Newtonsoft");
        Console.WriteLine(JsonConvert.SerializeObject(objNewtonsoft));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(objSystemText));

        Console.WriteLine("----------------------------");
    }
}
