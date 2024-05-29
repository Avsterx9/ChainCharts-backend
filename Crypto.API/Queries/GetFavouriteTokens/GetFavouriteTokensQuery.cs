using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetFavouriteTokens;

public record GetFavouriteTokensQuery() : IRequest<IEnumerable<FavouriteTokenDto>>;