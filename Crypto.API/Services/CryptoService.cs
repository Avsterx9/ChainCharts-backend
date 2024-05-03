using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;

namespace Crypto.API.Services;

public class CryptoService : ICryptoService
{
    private readonly ICacheService _cacheService;

    public CryptoService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query)
    {
        var tokens = await _cacheService.GetCGTokensAsync();

        return tokens;
    }

    public async Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days, CancellationToken cancellationToken)
    {
        var data = await _cacheService.GetPriceDataAsync(tokenName, days);

        return data;
    }
}
