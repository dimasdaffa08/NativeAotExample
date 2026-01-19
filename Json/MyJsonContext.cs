using NativeAotExample.Models;
using System.Text.Json.Serialization;

namespace NativeAotExample.Json;

[JsonSerializable(typeof(List<OrderDto>))]
public partial class MyJsonContext : JsonSerializerContext { }
