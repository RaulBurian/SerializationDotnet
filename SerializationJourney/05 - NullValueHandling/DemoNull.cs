using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationJourney._05___NullValueHandling;

public class DemoNull
{
    public string Name { get; set; }

    public int Value { get; set; }
}

#region Hidden

public class NullableIntConverter: JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType is not JsonTokenType.Null ? reader.GetInt32() : 0;
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}

#endregion
