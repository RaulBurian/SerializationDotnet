using Newtonsoft.Json;

namespace SerializationJourney._06___SerializationEncoding;

public static class SerializationEncoding
{
    public static void SerializationEncodingExamples()
    {
        var obj = new DemoEncoding
        {
            Value = """
                    This is a string that will be serialized and encoded
                    The \" will be escaped
                    But not only that
                    In some scenarios
                    Also < / >
                    And &
                    Basically all HTML chars might be
                    """
        };
        obj.Value = obj.Value.Replace("\r\n", " ");

        Console.WriteLine("Newtonsoft");

        Console.WriteLine(JsonConvert.SerializeObject(obj));

        Console.WriteLine("----------------------------");

        Console.WriteLine("System Text Json");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(obj));

        Console.WriteLine("----------------------------");
    }
}
