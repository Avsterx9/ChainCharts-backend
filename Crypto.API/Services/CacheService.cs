using Crypto.API.Models.Dto;
using Crypto.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crypto.API.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly ICoinGeckoManager _coingGeckoManager;

    public CacheService(
        IDistributedCache distributedCache,
        ICoinGeckoManager coinGeckoManager)
    {
        _distributedCache = distributedCache;
        _coingGeckoManager = coinGeckoManager;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync()
    {
        string cacheKey = "coinGeckoTokens";

        return await GetCachedData<IEnumerable<CryptoTokenDto>>(
            cacheKey,
            () => _coingGeckoManager.GetCoinGeckoTokensAsync(),
            TimeSpan.FromMinutes(10));
    }

    public async Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days)
    {
        string cacheKey = $"priceData_{tokenName}_{days}";

        return await GetCachedData<PriceDataDto>(
            cacheKey,
            () => _coingGeckoManager.GetPriceDataAsync(tokenName, days),
            TimeSpan.FromMinutes(10));
    }

    public async Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName)
    {
        string cacheKey = $"tokenDescription_{tokenName}";

        return await GetCachedData<TokenDescriptionDto>(
            cacheKey,
            () => _coingGeckoManager.GetTokenDescriptionAsync(tokenName),
            TimeSpan.FromMinutes(10));
    }

    public async Task<GlobalDataDto> GetGlobalDataAsync()
    {
        string cacheKey = "global";

        return await GetCachedData<GlobalDataDto>(
            cacheKey,
            () => _coingGeckoManager.GetGlobalDataAsync(),
            TimeSpan.FromMinutes(10));
    }

    private async Task<T> GetCachedData<T>(string cacheKey, Func<Task<T>> fetchData, TimeSpan cacheDuration)
    {
        string serializedData = await _distributedCache.GetStringAsync(cacheKey);
        if (serializedData != null)
        {
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        T data = await fetchData();
        serializedData = JsonConvert.SerializeObject(data);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(cacheDuration);

        await _distributedCache.SetStringAsync(cacheKey, serializedData, options);
        return data;
    }
}
