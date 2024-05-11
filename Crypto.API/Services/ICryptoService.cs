using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;

namespace Crypto.API.Services;
public interface ICryptoService
{
    Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query);
    Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days, CancellationToken cancellationToken);
    Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName, CancellationToken cancellationToken);
    Task<GlobalDataDto> GetGlobalDataAsync(CancellationToken cancellationToken);
}