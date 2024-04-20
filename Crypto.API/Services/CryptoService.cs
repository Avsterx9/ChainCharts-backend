using AutoMapper;
using Common.Services;
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
}
