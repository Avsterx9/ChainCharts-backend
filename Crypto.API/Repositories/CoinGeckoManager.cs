using Crypto.API.Models.Dto;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Crypto.API.Repositories;

public class CoinGeckoManager : ICoinGeckoManager
{
    private readonly string _coinGeckoURL = "https://api.coingecko.com/api/v3";
    private readonly IHttpClientFactory _httpClientFactory;

    public CoinGeckoManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCoinGeckoTokensAsync() =>
        await SendRequestAndGetResponseAsync<IEnumerable<CryptoTokenDto>>($"{_coinGeckoURL}/coins/markets?vs_currency=usd&order=market_cap_desc", HttpMethod.Get);

    public async Task<PriceDataDto> GetPriceDataAsync(string TokenName, int Days) =>
        await SendRequestAndGetResponseAsync<PriceDataDto>($"{_coinGeckoURL}/coins/{TokenName}/market_chart?vs_currency=usd&days={Days}", HttpMethod.Get);

    public async Task<TokenDescriptionDto> GetTokenDescriptionAsync(string TokenName) =>
        await SendRequestAndGetResponseAsync<TokenDescriptionDto>($"{_coinGeckoURL}/coins/{TokenName}", HttpMethod.Get);

    public async Task<GlobalDataDto> GetGlobalDataAsync() =>
        await SendRequestAndGetResponseAsync<GlobalDataDto>($"{_coinGeckoURL}/global", HttpMethod.Get);


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
