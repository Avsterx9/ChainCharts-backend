using Crypto.API.Models.Entities;

namespace Crypto.API.Repositories;
public interface ICryptoRepository
{
    Task<FavouriteToken> AddFavouriteTokenAsync(FavouriteToken token, CancellationToken ct);
    Task<List<FavouriteToken>> GetFavouriteTokensAsync(Guid userId, CancellationToken ct);
    Task DeleteFavouriteToken(FavouriteToken token, CancellationToken ct);
    Task<FavouriteToken?> GetFavouriteTokenById(string TokenId, CancellationToken ct);

    Task<UserToken> AddUserTokenAsync(UserToken token, CancellationToken ct);
    Task<List<UserToken>> GetUserTokensAsync(Guid userId, CancellationToken ct);
    Task DeleteUserToken(UserToken token, CancellationToken ct);
    Task<UserToken?> GetUserTokenById(string TokenId, CancellationToken ct);
}