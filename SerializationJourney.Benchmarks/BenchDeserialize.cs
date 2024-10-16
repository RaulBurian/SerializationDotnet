using System.Text;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationJourney.Benchmarks;

[MemoryDiagnoser]
public class BenchDeserialize
{
    private static string _entry = """
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

    private static DemoEntry _demoEntry = JsonSerializer.Deserialize<DemoEntry>(_entry);

    private static readonly byte[] DemoBytes = Encoding.UTF8.GetBytes(_entry);

    private static readonly Newtonsoft.Json.JsonSerializer NewtonsoftStreamSerializer = new Newtonsoft.Json.JsonSerializer();


    [Benchmark]
    public DemoEntry NormalCreate()
    {
        return new DemoEntry
        {
            Id = Guid.Parse("d271e035-5b8b-4d52-bf7b-5f0e1ad8beaa"),
            Name = "Sample Name",
            EffectiveDate = DateTime.Parse("2024-10-14T12:00:00"),
            Grade = 5,
            AList =
            [
                "Item1",
                "Item2",
                "Item3"
            ],
            ComplexObject = new ComplexType
            {
                OneProp = "Value1",
                AnotherProp = "Value2"
            }
        };
    }

    [Benchmark]
    public DemoEntry SystemTextStringRegularDeserialize()
    {
        return JsonSerializer.Deserialize<DemoEntry>(_entry);
    }

    [Benchmark]
    public DemoEntry SystemTextStringSourceGenDeserialize()
    {
        return JsonSerializer.Deserialize(_entry, DemoEntryContext.Default.DemoEntry);
    }

    [Benchmark]
    public DemoEntry NewtonsoftStringDeserialize()
    {
       return JsonConvert.DeserializeObject<DemoEntry>(_entry);
    }

    [Benchmark]
    public DemoEntry SystemTextStreamRegularDeserialize()
    {
        var stream = new MemoryStream(DemoBytes);
        return JsonSerializer.Deserialize<DemoEntry>(stream);
    }

    [Benchmark]
    public DemoEntry SystemTextStreamSourceGenDeserialize()
    {
        var stream = new MemoryStream(DemoBytes);
        return JsonSerializer.Deserialize(stream, DemoEntryContext.Default.DemoEntry);
    }

    [Benchmark]
    public DemoEntry NewtonsoftStreamDeserialize()
    {
        var stream = new MemoryStream(DemoBytes);
        var jsonReader = new JsonTextReader(new StreamReader(stream));

        return NewtonsoftStreamSerializer.Deserialize<DemoEntry>(jsonReader);
    }
}
