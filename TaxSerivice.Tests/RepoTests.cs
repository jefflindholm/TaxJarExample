using Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;
using Xunit;
namespace TaxSerivice.Tests;

public class RepoTests
{
    [Fact]
    public void Repo_Should_Return_Object_For_Id()
    {
        var repo = new tax_api.Repositories.OrderRepository(new NullLogger<tax_api.Repositories.OrderRepository>());
        var order = repo.GetOrderById(1);
        Assert.NotNull(order);
    }
}