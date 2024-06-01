using Crypto.API.Models.Dto;
using Crypto.API.Models.Responses;
using MediatR;

namespace Crypto.API.Commands.AddUserToken;

public record AddUserTokenCommand(UserTokenLiteDto model) : IRequest<StandardResponse>;
