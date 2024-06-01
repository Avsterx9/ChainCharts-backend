using Common.Services;
using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Repositories;

namespace Crypto.API.Services;

public class CoinGeckoService : ICoinGeckoService
{
    private readonly ICacheService _cacheService;
    private readonly ICryptoRepository _repository;
    private readonly IUserContextService _userContextService;

    public CoinGeckoService(
        ICacheService cacheService,
        ICryptoRepository cryptoRepository,
        IUserContextService userContextService)
    {
        _cacheService = cacheService;
        _repository = cryptoRepository;
        _userContextService = userContextService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query)
    {
        var userId = _userContextService.GetUserId();

        var tokens = await _cacheService.GetCGTokensAsync();
        var favourites = await _repository.GetFavouriteTokensAsync(userId, new CancellationToken());

        foreach(var fav in favourites)
        {
            var token = tokens.FirstOrDefault(x => x.Id == fav.TokenId);

            if (token is null) continue;

            token.IsFavourite = true;
        }

        return tokens;
    }

    public async Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days, CancellationToken cancellationToken)
    {
        var data = await _cacheService.GetPriceDataAsync(tokenName, days);

        return data;
    }

    public async Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName, CancellationToken cancellationToken)
    {
        var tokenDesc = await _cacheService.GetTokenDescriptionAsync(tokenName);

        return tokenDesc;
    }

    public async Task<GlobalDataDto> GetGlobalDataAsync(CancellationToken cancellationToken)
    {
        var data = await _cacheService.GetGlobalDataAsync();

        return data;
    }
}
