using Crypto.API.Models.Dto;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Crypto.API.Repositories;

public class CoinGeckoRepository : ICoinGeckoRepository
{
    private readonly string _coinGeckoURL = "https://api.coingecko.com/api/v3";
    private readonly IHttpClientFactory _httpClientFactory;

    public CoinGeckoRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCoinGeckoTokensAsync() =>
        await SendRequestAndGetResponseAsync<IEnumerable<CryptoTokenDto>>($"{_coinGeckoURL}/coins/markets?vs_currency=usd&order=market_cap_desc", HttpMethod.Get);


    private async Task<T> SendRequestAndGetResponseAsync<T>(string url, HttpMethod method, object? content = null, string? token = null)
    {
        var httpRequestMessage = new HttpRequestMessage(method, url);
        if (content is not null)
            httpRequestMessage.Content = JsonContent.Create(content);

        var httpClient = CreateHttpClient(token);
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(contentStream);
        }

        return default;
    }

    private HttpClient CreateHttpClient(string? token)
    {
        var httpClient = _httpClientFactory.CreateClient();

        if (token is not null)
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        httpClient.DefaultRequestHeaders.Add("User-Agent", "CryptoCharts/1.0");

        return httpClient;
    }
}
