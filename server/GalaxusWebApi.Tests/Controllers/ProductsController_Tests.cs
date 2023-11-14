using Microsoft.AspNetCore.Mvc.Testing;

namespace GalaxusWebApi.Tests.Controllers;

public class ProductsController_Tests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProductsController_Tests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetProducts_ReturnsListOfProducts()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/products");
        var stringResponse = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        Assert.Equal("[]", stringResponse);
    }
}
