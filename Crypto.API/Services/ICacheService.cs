using Crypto.API.Models.Dto;

namespace Crypto.API.Services;
public interface ICacheService
{
    Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync();
    Task<PriceDataDto> GetPriceDataAsync(string tokenName, int days);
    Task<TokenDescriptionDto> GetTokenDescriptionAsync(string tokenName);
}