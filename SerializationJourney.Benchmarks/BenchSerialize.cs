using System.Text;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationJourney.Benchmarks;

[MemoryDiagnoser]
public class BenchSerialize
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

    [Benchmark]
    public string BaselineMemoryString()
    {
        return new string("""{"Id":"d271e035-5b8b-4d52-bf7b-5f0e1ad8beaa","Name":"Sample Name","EffectiveDate":"2024-10-14T12:00:00","Grade":5,"AList":["Item1","Item2","Item3"],"ComplexObject":{"OneProp":"Value1","AnotherProp":"Value2"}}""");
    }

    [Benchmark]
    public byte[] BaselineMemoryBytes()
    {
        return """{"Id":"d271e035-5b8b-4d52-bf7b-5f0e1ad8beaa","Name":"Sample Name","EffectiveDate":"2024-10-14T12:00:00","Grade":5,"AList":["Item1","Item2","Item3"],"ComplexObject":{"OneProp":"Value1","AnotherProp":"Value2"}}"""u8.ToArray();
    }

    [Benchmark]
    public string SystemTextStringRegular()
    {
        return JsonSerializer.Serialize(_demoEntry);
    }

    [Benchmark]
    public string SystemTextStringSourceGen()
    {
        return JsonSerializer.Serialize(_demoEntry, DemoEntryContext.Default.DemoEntry);
    }

    [Benchmark]
    public byte[] SystemTextBytesRegular()
    {
        return JsonSerializer.SerializeToUtf8Bytes(_demoEntry);
    }

    [Benchmark]
    public byte[] SystemTextBytesSourceGen()
    {
        return JsonSerializer.SerializeToUtf8Bytes(_demoEntry, DemoEntryContext.Default.DemoEntry);
    }

    [Benchmark]
    public string NewtonsoftString()
    {
        return JsonSerializer.Serialize(_demoEntry);
    }

    [Benchmark]
    public byte[] NewtonsoftBytesReg()
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(_demoEntry));
    }

    [Benchmark]
    public byte[] NewtonsoftBytesBAD()
    {
        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream);
        var w = new JsonTextWriter(streamWriter);
        var jsonSerializer = new Newtonsoft.Json.JsonSerializer();

        jsonSerializer.Serialize(w, _demoEntry);

        streamWriter.Flush();

        memoryStream.Position = 0;

        return new BinaryReader(memoryStream, Encoding.UTF8).ReadBytes((int)memoryStream.Length);
    }
}
