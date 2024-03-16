using MediatR;
using Users.API.Responses;
using Users.API.Services;

namespace Users.API.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserService _usersService;

    public LoginCommandHandler(IUserService usersService)
    {
        _usersService = usersService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = await _usersService.GenerateJwtTokenAsync(request.Credentials, cancellationToken);

        return new LoginResponse(token);
    }
}
