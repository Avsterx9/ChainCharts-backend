using AutoMapper;
using Common.Services;
using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Repositories;

namespace Crypto.API.Services;

public class CryptoService : ICryptoService
{
    private readonly ICoinGeckoRepository _coinGeckoRepository;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public CryptoService(
        IMapper mapper,
        IUserContextService userContextService,
        ICoinGeckoRepository coinGeckoRepository)
    {
        _mapper = mapper;
        _userContextService = userContextService;
        _coinGeckoRepository = coinGeckoRepository;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query)
    {
        var tokens = await _coinGeckoRepository.GetCoinGeckoTokensAsync();

        return tokens;
    }
}
