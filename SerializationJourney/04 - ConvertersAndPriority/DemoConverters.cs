using System.Text.Json;
using Newtonsoft.Json;

namespace SerializationJourney._04___ConvertersAndPriority;

[System.Text.Json.Serialization.JsonConverter(typeof(ConverterStj))]
[Newtonsoft.Json.JsonConverter(typeof(ConverterNewtonsoft))]
public record DemoConverters
{
    public string Name { get; set; }

    public DateTime Timestamp { get; set; }
}

public class ConverterNewtonsoft : Newtonsoft.Json.JsonConverter<DemoConverters>
{
    public override void WriteJson(JsonWriter writer, DemoConverters value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteRawValue($"{value}");
    }

    public override DemoConverters ReadJson(JsonReader reader, Type objectType, DemoConverters existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        reader.Read();
        reader.Read();

        return new DemoConverters
        {
            Name = "myName",
            Timestamp = DateTime.UtcNow
        };
    }
}

public class ConverterStj : System.Text.Json.Serialization.JsonConverter<DemoConverters>
{
    public override DemoConverters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.Read();
        reader.Read();

        return new DemoConverters
        {
            Name = "myName",
            Timestamp = DateTime.UtcNow
        };
    }

    public override void Write(Utf8JsonWriter writer, DemoConverters value, JsonSerializerOptions options)
    {
        writer.WriteRawValue($"{value}", skipInputValidation: true);
    }
}

#region Hidden

public class StringConverterNewtonsoft : Newtonsoft.Json.JsonConverter<string>
{
    public override void WriteJson(JsonWriter writer, string value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue($"{value} is really nice");
    }

    public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        reader.ReadAsString();

        return "myString";
    }
}

public class StringConverterStj : System.Text.Json.Serialization.JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.GetString();

        return "myString";
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value} is really nice");
    }
}

public class ConverterNewtonsoft2 : Newtonsoft.Json.JsonConverter<DemoConverters>
{
    public override void WriteJson(JsonWriter writer, DemoConverters value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteRawValue($"{value} and something else");
    }

    public override DemoConverters ReadJson(JsonReader reader, Type objectType, DemoConverters existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        reader.Read();
        reader.Read();

        return new DemoConverters
        {
            Name = "myName",
            Timestamp = DateTime.UtcNow
        };
    }
}

public class ConverterStj2 : System.Text.Json.Serialization.JsonConverter<DemoConverters>
{
    public override DemoConverters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.Read();
        reader.Read();

        return new DemoConverters
        {
            Name = "myName",
            Timestamp = DateTime.UtcNow
        };
    }

    public override void Write(Utf8JsonWriter writer, DemoConverters value, JsonSerializerOptions options)
    {
        writer.WriteRawValue($"{value} and something else", skipInputValidation: true);
    }
}

#endregion
