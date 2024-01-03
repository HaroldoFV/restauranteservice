using System.Net.Http.Headers;

namespace IntegrationTests.Factories;

public class CustomWebApplicationFactory : IHttpClientFactory
{
    private string url;

    public CustomWebApplicationFactory(string url)
    {
        this.url = url;
    }

    public CustomWebApplicationFactory()
    {
    }

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}