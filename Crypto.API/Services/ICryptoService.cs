using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;

namespace Crypto.API.Services;
public interface ICryptoService
{
    Task<IEnumerable<CryptoTokenDto>> GetCGTokensAsync(GetCGTokensQuery query);
}