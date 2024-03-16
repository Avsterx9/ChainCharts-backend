using MediatR;
using Users.API.Models.Responses;
using Users.API.Services;

namespace Users.API.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var createdUser = await _userService.CreateUserAsync(command.RegistrationDto, cancellationToken);

        return new CreateUserResponse
        {
            Id = createdUser.Id,
            Message = "User added successfully",
            Success = true
        };
    }
}
