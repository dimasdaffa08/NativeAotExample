using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.AddConsole();

// Manual DI
builder.Services.AddScoped<IOrderService, OrderService>();

// JSON source generator
builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.TypeInfoResolverChain.Insert(0, MyJsonContext.Default);
});

// OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapGet("/orders", (IOrderService svc) => svc.GetOrders());

app.Run();

[JsonSerializable(typeof(List<OrderDto>))]
public partial class MyJsonContext : JsonSerializerContext { }

public record OrderDto(int Id, decimal Amount);

public interface IOrderService
{
    List<OrderDto> GetOrders();
}

public class OrderService : IOrderService
{
    public List<OrderDto> GetOrders() =>
        [new(1, 100_000), new(2, 250_000)];
}
