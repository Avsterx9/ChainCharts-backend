using Crypto.API.Models.Dto;

namespace Crypto.API.Services;
public interface ICryptoService
{
    Task<bool> AddFavouriteTokenAsync(string TokenId, CancellationToken ct);
    Task<bool> DeleteFavouriteTokenAsync(string TokenId, CancellationToken ct);
    Task<IEnumerable<FavouriteTokenDto>> GetFavouriteTokensAsync(CancellationToken ct);
}