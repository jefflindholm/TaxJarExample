using tax_api.Entities;

namespace tax_api.Repositories;

public interface IOrderRepository
{
    OrderEntity GetOrderById(int orderId);
}
