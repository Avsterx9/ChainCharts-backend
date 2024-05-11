using Crypto.API.Models.Dto;

namespace Crypto.API.Repositories;
public interface ICoinGeckoManager
{
    Task<IEnumerable<CryptoTokenDto>> GetCoinGeckoTokensAsync();
    Task<PriceDataDto> GetPriceDataAsync(string TokenName, int Days);
    Task<TokenDescriptionDto> GetTokenDescriptionAsync(string TokenName);
    Task<GlobalDataDto> GetGlobalDataAsync();
}