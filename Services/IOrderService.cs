using NativeAotExample.Models;

namespace NativeAotExample.Services;

public interface IOrderService
{
    List<OrderDto> GetOrders();
}
