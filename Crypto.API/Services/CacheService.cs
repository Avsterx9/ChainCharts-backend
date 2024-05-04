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
        IEnumerable<CryptoTokenDto> tokens;

        string serializedTokens = await _distributedCache.GetStringAsync(cacheKey);

        if (serializedTokens != null)
        {
            return JsonConvert.DeserializeObject<IEnumerable<CryptoTokenDto>>(serializedTokens);
        }

        tokens = await _coingGeckoManager.GetCoinGeckoTokensAsync();
        serializedTokens = JsonConvert.SerializeObject(tokens);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

        await _distributedCache.SetStringAsync(cacheKey, serializedTokens, options);
        return tokens;
    }

    public async Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days)
    {
        string cacheKey = $"priceData_{tokenName}_{days}";

        PriceDataDto data;

        string serializedData = await _distributedCache.GetStringAsync(cacheKey);

        if (serializedData != null)
        {
            return JsonConvert.DeserializeObject<PriceDataDto>(serializedData);
        }

        data = await _coingGeckoManager.GetPriceDataAsync(tokenName, days);
        serializedData = JsonConvert.SerializeObject(data);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

        await _distributedCache.SetStringAsync(cacheKey, serializedData, options);
        return data;
    }

    public async Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName)
    {
        string cacheKey = $"tokenDescription_{tokenName}";

        TokenDescriptionDto data;

        string serializedData = await _distributedCache.GetStringAsync(cacheKey);

        if (serializedData != null)
        {
            return JsonConvert.DeserializeObject<TokenDescriptionDto>(serializedData);
        }

        data = await _coingGeckoManager.GetTokenDescriptionAsync(tokenName);
        serializedData = JsonConvert.SerializeObject(data);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

        await _distributedCache.SetStringAsync(cacheKey, serializedData, options);
        return data;
    }
}
