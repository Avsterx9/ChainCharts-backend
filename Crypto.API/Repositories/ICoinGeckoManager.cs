using Crypto.API.Models.Dto;

namespace Crypto.API.Repositories;
public interface ICoinGeckoManager
{
    Task<IEnumerable<CryptoTokenDto>> GetCoinGeckoTokensAsync();
}