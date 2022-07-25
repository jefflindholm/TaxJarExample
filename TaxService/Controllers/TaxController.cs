using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using tax_api.Entities;
using tax_api.Services;

namespace tax_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxController : ControllerBase
{
    private readonly ILogger<TaxController> _logger;
    private readonly ITaxService _service;

    public TaxController(ILogger<TaxController> logger, ITaxService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("location/{zipcode}", Name = "GetTaxForLocation")]
    public ActionResult<object> GetTaxForLocation(string zipcode, string? countryCode)
    {
        return _service.GetTaxForLocation(zipcode, countryCode);
    }

    [HttpGet("order/{orderId}", Name = "GetTaxForOrder")]
    public ActionResult<object> GetTaxForOrder(int orderId)
    {
        return _service.GetTaxForOrder(orderId);
    }
}
