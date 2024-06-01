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
                TokenId = favouriteToken.TokenId,
                Name = currentToken.Name,
                Price = currentToken.CurrentPrice,
                Symbol = currentToken.Symbol,
            });
        }

        return response;
    }

    public async Task<bool> DeleteFavouriteTokenAsync(string TokenId, CancellationToken ct)
    {
        var token = await _cryptoRepository.GetFavouriteTokenById(TokenId, ct);

        if (token is null)
            throw new NotFoundException(ExceptionCodes.TOKEN_NOT_FOUND);

        await _cryptoRepository.DeleteFavouriteToken(token, ct);
        return true;
    }

    public async Task<bool> AddUserTokenAsync(UserTokenLiteDto model, CancellationToken ct)
    {
        var userId = _userContextService.GetUserId();

        var tokens = await _cryptoRepository.GetUserTokensAsync(userId, ct);

        if (tokens.Any(x => x.TokenId == model.TokenId))
            return true;

        var userToken = new UserToken
        {
            UserId = userId,
            TokenId = model.TokenId,
            CreatedDate = DateTime.Now,
            Quantity = model.Quantity
        };

        await _cryptoRepository.AddUserTokenAsync(userToken, ct);
        return true;
    }

    public async Task<IEnumerable<UserTokenDto>> GetUserTokensAsync(CancellationToken ct)
    {
        var userId = _userContextService.GetUserId();

        var userTokens = await _cryptoRepository.GetUserTokensAsync(userId, ct);
        var tokens = await _cacheService.GetCGTokensAsync();

        var response = new List<UserTokenDto>();
        foreach (var userToken in userTokens)
        {
            var currentToken = tokens.FirstOrDefault(x => x.Id == userToken.TokenId);

            if (currentToken is null) continue;

            response.Add(new UserTokenDto
            {
                Image = currentToken.Image,
                TokenId = userToken.TokenId,
                Name = currentToken.Name,
                Price = currentToken.CurrentPrice,
                Symbol = currentToken.Symbol,
                Quantity = userToken.Quantity,
                ValueEstimation = currentToken.CurrentPrice * userToken.Quantity
            });
        }

        return response;
    }

    public async Task<bool> DeleteUserTokenAsync(string TokenId, CancellationToken ct)
    {
        var token = await _cryptoRepository.GetUserTokenById(TokenId, ct);

        if (token is null)
            throw new NotFoundException(ExceptionCodes.TOKEN_NOT_FOUND);

        await _cryptoRepository.DeleteUserToken(token, ct);
        return true;
    }

    public async Task<WalletEstimationDto> GetUserWalletEstimationAsync(CancellationToken cancellationToken)
    {
        var userId = _userContextService.GetUserId();

        var userTokens = await _cryptoRepository.GetUserTokensAsync(userId, cancellationToken);
        var tokens = await _cacheService.GetCGTokensAsync();

        if (!userTokens.Any())
            return new WalletEstimationDto { TotalEstimation = 0 };

        var response = new WalletEstimationDto();
        response.TokenValues = new List<TokenValueDto>();
        foreach (var userToken in userTokens)
        {
            var currentToken = tokens.FirstOrDefault(x => x.Id == userToken.TokenId);

            if (currentToken is null) continue;

            response.TokenValues.Add(new TokenValueDto
            {
                Name = currentToken.Name,
                Value = currentToken.CurrentPrice * userToken.Quantity
            });
        }

        response.TotalEstimation = response.TokenValues.Sum(x => x.Value);

        return response;
    }
}
