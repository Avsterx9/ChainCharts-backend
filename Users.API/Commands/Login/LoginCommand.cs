using MediatR;
using Users.API.Responses;

namespace Users.API.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;
