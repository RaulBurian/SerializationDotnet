using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializationJourney.Benchmarks;

[MemoryDiagnoser]
public class BenchBig
{
    public static readonly string Text = File.ReadAllText("BigSample.json");
    public static readonly DemoEntry[] Demos = JsonSerializer.Deserialize<DemoEntry[]>(Text);

    [Benchmark]
    public DemoEntry[] SystemTextJsonDes()
    {
        return JsonSerializer.Deserialize<DemoEntry[]>(Text);
    }

    [Benchmark]
    public DemoEntry[] SystemTextJsonSourceGenDes()
    {
        return JsonSerializer.Deserialize<DemoEntry[]>(Text, DemoEntryArrayContext.Default.DemoEntryArray);
    }

    [Benchmark]
    public DemoEntry[] NewtonsoftDes()
    {
        return JsonConvert.DeserializeObject<DemoEntry[]>(Text);
    }
    
    [Benchmark]
    public string SystemTextJsonSer()
    {
        return JsonSerializer.Serialize(Demos);
    }

    [Benchmark]
    public string SystemTextJsonSourceGenSer()
    {
        return JsonSerializer.Serialize(Demos, DemoEntryArrayContext.Default.DemoEntryArray);
    }

    [Benchmark]
    public string NewtonsoftSer()
    {
        return JsonConvert.SerializeObject(Demos);
    }
}
