using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetUserTokens;

public record GetUserTokensQuery : IRequest<IEnumerable<UserTokenDto>>;
