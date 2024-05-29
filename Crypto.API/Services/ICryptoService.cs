using Crypto.API.Models.Dto;

namespace Crypto.API.Services;
public interface ICryptoService
{
    Task<bool> AddFavouriteTokenAsync(string TokenId, CancellationToken ct);
    Task<bool> DeleteFavouriteToken(string TokenId, CancellationToken ct);
    Task<IEnumerable<FavouriteTokenDto>> GetFavouriteTokensAsync(CancellationToken ct);
}