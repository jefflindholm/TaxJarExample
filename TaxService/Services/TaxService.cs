using Taxjar;
using tax_api.Entities;
using tax_api.Repositories;

namespace tax_api.Services;

public class TaxService : ITaxService
{
    private readonly ILogger<TaxService> _logger;
    private readonly TaxjarApi _client;
    private readonly IOrderRepository _repo;

    public TaxService(ILogger<TaxService> logger, IOrderRepository repo)
    {
        _logger = logger;
        _client = new TaxjarApi("REPLACE THIS WITH API KEY");
        _repo = repo;
    }

    public object GetTaxForLocation(string zipCode, string countryCode = "US")
    {
        if (countryCode == null) countryCode = "US";
        var rates = _client.RatesForLocation(zipCode, new { country = countryCode });
        _logger.LogInformation(rates.ToString());
        return rates;
    }
    
    public object GetTaxForOrder(int orderId)
    {
        var order = _repo.GetOrderById(orderId);
        var rates = _client.TaxForOrder(order);
        return rates;
    }
}
