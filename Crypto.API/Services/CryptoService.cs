using AutoMapper;
using Common.Services;
using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Crypto.API.Services;

public class CryptoService : ICryptoService
{
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;
    private readonly ICacheService _cacheService;

    public CryptoService(
        IMapper mapper,
        IUserContextService userContextService,
        ICacheService cacheService)
    {
        _mapper = mapper;
        _userContextService = userContextService;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query)
    {
        var tokens = await _cacheService.GetCGTokensAsync();

        return tokens;
    }
}
