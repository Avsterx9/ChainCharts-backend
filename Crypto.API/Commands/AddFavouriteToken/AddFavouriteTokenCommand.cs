using Crypto.API.Models.Responses;
using MediatR;

namespace Crypto.API.Commands.AddFavouriteToken;

public record AddFavouriteTokenCommand(string TokenName) : IRequest<StandardResponse>;
