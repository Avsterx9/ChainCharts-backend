using Crypto.API.Models.Dto;

namespace Crypto.API.Services;
public interface ICacheService
{
    Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync();
}