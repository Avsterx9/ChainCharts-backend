using Crypto.API.Models.Dto;

namespace Crypto.API.Repositories;
public interface ICoinGeckoRepository
{
    Task<IEnumerable<CryptoTokenDto>> GetCoinGeckoTokensAsync();
}