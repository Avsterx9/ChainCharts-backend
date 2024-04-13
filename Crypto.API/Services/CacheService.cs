using Crypto.API.Models.Dto;
using Crypto.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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

}
