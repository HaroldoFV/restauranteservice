using IntegrationTests.Factories;

namespace IntegrationTests;

public class RestauranteControllerIntegrationTests
{
    private HttpClient _client = null;

    public RestauranteControllerIntegrationTests()
    {
        _client = new CustomWebApplicationFactory("https://localhost:5000").CreateClient("item");
    }

    [Fact]
    public async Task GetRestaurantes_ReturnsSuccessStatusCode()
    {
        // Arrange
        // Act
        var response = await _client.GetAsync("/api/item/restaurante");

        // Assert
        Assert.True(
            response.IsSuccessStatusCode,
            $"Expected success status code but got {response.StatusCode} with content {await response.Content.ReadAsStringAsync()}");
    }
}