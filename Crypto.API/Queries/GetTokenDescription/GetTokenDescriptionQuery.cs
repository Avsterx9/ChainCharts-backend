using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetTokenDescription;

public record GetTokenDescriptionQuery(string tokenName) : IRequest<TokenDescriptionDto>;
