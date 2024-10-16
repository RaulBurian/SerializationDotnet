using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace SerializationJourney._09___HttpClientExtensions;

public static class HttpClientExt
{
    public static async Task HttpClientExtExamples()
    {
        var services = new ServiceCollection();

        services.AddHttpClient("Client", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5147");
        });

        var sp = services.BuildServiceProvider();
        var httpclientFactory = sp.GetRequiredService<IHttpClientFactory>();

        var httpClient = httpclientFactory.CreateClient("Client");

        await GetExtension(httpClient);
        await GetStream(httpClient);
    }

    private static async Task GetExtension(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("items-small", HttpCompletionOption.ResponseHeadersRead);

        var todos = await response.Content.ReadFromJsonAsync<Todo[]>();

        Console.WriteLine(todos.Length);
        Console.WriteLine(JsonSerializer.Serialize(todos));
    }

    private static async Task GetStream(HttpClient httpClient)
    {
        await foreach (var todo in httpClient.GetFromJsonAsAsyncEnumerable<Todo>("items-small"))
        {
            Console.WriteLine(todo);
        }
    }
}

record Todo(int Index, string Name, string ExtraProp);
