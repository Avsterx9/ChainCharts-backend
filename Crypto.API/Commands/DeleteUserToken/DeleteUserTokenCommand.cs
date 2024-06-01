using Crypto.API.Models.Responses;
using MediatR;

namespace Crypto.API.Commands.DeleteUserToken;

public record DeleteUserTokenCommand(string TokenId) : IRequest<StandardResponse>;
