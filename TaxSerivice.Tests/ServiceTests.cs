using System.Reflection;
using System.Data.Common;
using System.ComponentModel.Design;
using Microsoft.Extensions.Logging.Abstractions;
using tax_api.Entities;
using tax_api.Repositories;
using tax_api.Services;
namespace TaxSerivice.Tests;

public class ServiceTests
{
    class Repository : IOrderRepository {
       public OrderEntity GetOrderById(int id) {
            return new OrderEntity {
                id = 1,
                from_country = "US",
                from_zip = "34243",
                from_state = "FL",
                to_country = "US",
                to_zip = "34243",
                to_state = "FL",
                to_city = "Sarasota",
                amount = 20,
                shipping = 1.5F,
            };
       }
    }
    [Fact]
    public void Should_Return_6_Percent_For_Zip_34243()
    {
        var repo = new Repository();
        var service = new TaxService(new NullLogger<TaxService>(), repo);
        var data = service.GetTaxForLocation("34243");
        Assert.NotNull(data);
        var prop = data.GetType().GetProperty("StateRate");
        var val = prop.GetValue(data);
        Assert.Equal(val, (Decimal)0.06);
    }
    [Fact]
    public void Should_Return_7_Percent_Tax_On_Order() {
        
        var repo = new Repository();
        var service = new TaxService(new NullLogger<TaxService>(), repo);
        var data = service.GetTaxForOrder(1);
        var prop = data.GetType().GetProperty("AmountToCollect");
        var val = prop.GetValue(data);
        Assert.Equal(val, (Decimal)1.4);
    }
}