using tax_api.Entities;
namespace tax_api.Services;

public interface ITaxService
{
    object GetTaxForLocation(string zipcode, string countryCode);
    object GetTaxForOrder(int orderId);
}
