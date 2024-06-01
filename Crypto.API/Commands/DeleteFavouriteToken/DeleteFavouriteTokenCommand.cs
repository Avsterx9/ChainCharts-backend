using Crypto.API.Models.Responses;
using MediatR;

namespace Crypto.API.Commands.DeleteFavouriteToken;

public record DeleteFavouriteTokenCommand(string TokenId) : IRequest<StandardResponse>;
