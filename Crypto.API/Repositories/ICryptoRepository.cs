using Crypto.API.Models.Entities;

namespace Crypto.API.Repositories;
public interface ICryptoRepository
{
    Task<FavouriteToken> AddFavouriteTokenAsync(FavouriteToken token, CancellationToken ct);
    Task<List<FavouriteToken>> GetFavouriteTokensAsync(Guid userId, CancellationToken ct);
    Task DeleteFavouriteToken(FavouriteToken token, CancellationToken ct);
    Task<FavouriteToken?> GetTokenById(string TokenId, CancellationToken ct);
}