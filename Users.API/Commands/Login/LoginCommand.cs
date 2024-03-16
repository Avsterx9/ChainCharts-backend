using MediatR;
using Users.API.Models.Dto.Auth;
using Users.API.Responses;

namespace Users.API.Commands.Login;

public record LoginCommand(UserCredentialsDto Credentials) : IRequest<LoginResponse>;
