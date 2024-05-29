using AutoMapper;
using Common.Exceptions;
using Common.Services;
using Crypto.API.Models.Dto;
using Crypto.API.Models.Entities;
using Crypto.API.Repositories;

namespace Crypto.API.Services;

public class CryptoService : ICryptoService
{
    private readonly ICryptoRepository _cryptoRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public CryptoService(
        ICryptoRepository usersRepository,
        IMapper mapper,
        IUserContextService userContextService,
        ICacheService cacheService)
    {
        _cryptoRepository = usersRepository;
        _mapper = mapper;
        _userContextService = userContextService;
        _cacheService = cacheService;
    }

    public async Task<bool> AddFavouriteTokenAsync(string TokenId, CancellationToken ct)
    {
        var userId = _userContextService.GetUserId();

        var tokens = await _cryptoRepository.GetFavouriteTokensAsync(userId, ct);

        if (tokens.Any(x => x.TokenId == TokenId))
            return true;

        var favouriteToken = new FavouriteToken
        {
            UserId = userId,
            TokenId = TokenId,
            CreatedDate = DateTime.Now,
        };

        await _cryptoRepository.AddFavouriteTokenAsync(favouriteToken, ct);
        return true;
    }

    public async Task<IEnumerable<FavouriteTokenDto>> GetFavouriteTokensAsync(CancellationToken ct)
    {
        var userId = _userContextService.GetUserId();

        var favouriteTokens = await _cryptoRepository.GetFavouriteTokensAsync(userId, ct);
        var tokens = await _cacheService.GetCGTokensAsync();

        var response = new List<FavouriteTokenDto>();
        foreach (var favouriteToken in favouriteTokens)
        {
            var currentToken = tokens.FirstOrDefault(x => x.Id == favouriteToken.TokenId);

            if (currentToken is null) continue;

            response.Add(new FavouriteTokenDto
            {
                Image = currentToken.Image,
                TokenId = favouriteToken.TokenId
            });
        }

        return response;
    }

    public async Task<bool> DeleteFavouriteToken(string TokenId, CancellationToken ct)
    {
        var token = await _cryptoRepository.GetTokenById(TokenId, ct);

        if (token is null)
            throw new NotFoundException(ExceptionCodes.TOKEN_NOT_FOUND);

        await _cryptoRepository.DeleteFavouriteToken(token, ct);
        return true;
    }
}
