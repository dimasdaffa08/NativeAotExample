using NativeAotExample.Models;

namespace NativeAotExample.Services;

public class OrderService : IOrderService
{
    public List<OrderDto> GetOrders() =>
        [new(1, 100_000), new(2, 250_000)];
}