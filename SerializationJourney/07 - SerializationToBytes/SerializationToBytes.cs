using System.Text;
using Newtonsoft.Json;

namespace SerializationJourney._07___SerializationToBytes;

public static class SerializationToBytes
{
    public static void SerializationToBytesExamples()
    {
        var obj = new DemoBytes
        {
            Value = "Just an object, does not really matter what is here"
        };

        var bytesNewtonsoft = GetBytesNewtonsoft(obj);
        var bytesNewtonsoftBAD = GetBytesNewtonsoftBAD(obj);
        var bytesStj = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);

        Console.WriteLine(bytesStj.SequenceEqual(bytesNewtonsoft));
        Console.WriteLine(bytesStj.SequenceEqual(bytesNewtonsoftBAD));
    }

    private static byte[] GetBytesNewtonsoft(DemoBytes obj)
    {
        return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
    }

    private static byte[] GetBytesNewtonsoftBAD(DemoBytes obj)
    {
        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream);
        var writer = new JsonTextWriter(streamWriter);
        var jsonSerializer = new Newtonsoft.Json.JsonSerializer();

        jsonSerializer.Serialize(writer, obj);

        streamWriter.Flush();

        memoryStream.Position = 0;

        return new BinaryReader(memoryStream, Encoding.UTF8).ReadBytes((int)memoryStream.Length);
    }
}
