using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetCGTokens;

public record GetCGTokensQuery : IRequest<IEnumerable<CryptoTokenDto>>;
