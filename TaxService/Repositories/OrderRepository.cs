using System.Linq;
using tax_api.Entities;

namespace tax_api.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ILogger<OrderRepository> _logger;
    public OrderRepository(ILogger<OrderRepository> logger) {
        _logger = logger;
    }
    public OrderEntity GetOrderById(int orderId) {
        _logger.LogInformation($"GetOrderById = {orderId}");
        var orders = _orders.Where(o => o.id == orderId);
        _logger.LogInformation($"length = {orders.Count()}");
        var order = orders.FirstOrDefault();
        _logger.LogInformation($"{order.from_zip}");
        return order;
    }

    private readonly List<OrderEntity> _orders = new List<OrderEntity>() {
        new OrderEntity {
            id = 1,
            from_country = "US",
            from_zip = "92093",
            from_state = "CA",
            from_city = "La Jolla",
            from_street = "9500 Gilman Drive",
            to_country = "US",
            to_zip = "90002",
            to_state = "CA",
            to_city = "Los Angeles",
            to_street = "1335 E 103rd St",
            amount = 15,
            shipping = 1.5F,
            line_items = new List<ItemEntity> {
                new ItemEntity {
                    id = "1",
                    quantity = 1,
                    product_tax_code = "20010",
                    unit_price = 15,
                    discount = 0
                }
            },
        },
        new OrderEntity {
            id = 2,
            from_country = "US",
            from_zip = "92093",
            from_state = "CA",
            to_country = "US",
            to_zip = "34243",
            to_state = "FL",
            to_city = "Sarasota",
            amount = 15,
            shipping = 1.5F,
        },
        new OrderEntity {
            id = 3,
            from_country = "US",
            from_zip = "34243",
            from_state = "FL",
            to_country = "US",
            to_zip = "34243",
            to_state = "FL",
            to_city = "Sarasota",
            amount = 20,
            shipping = 1.5F,
        },
    };
}