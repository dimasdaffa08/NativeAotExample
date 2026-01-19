using NativeAotExample.Json;
using NativeAotExample.Services;

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
