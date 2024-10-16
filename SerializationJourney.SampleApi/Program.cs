var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/todo", (Todo body) => Results.Ok(body));

app.MapGet("/items-small", () => BigAsyncStream(10).ToBlockingEnumerable());

app.MapGet("/items-big", () => BigAsyncStream(10000));

app.Run();

async IAsyncEnumerable<Todo> BigAsyncStream(int number)
{
    foreach (var idx in Enumerable.Range(0, number))
    {
        yield return new Todo(idx, $"Item number {idx}", "Extra prop");
        await Task.Delay(100);
    }
}

record Todo(int Index, string Name, string ExtraProp);
