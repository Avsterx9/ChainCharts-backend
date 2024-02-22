using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Users.API.Models.Entities;
using Users.API.Models.Responses;
using Users.API.Repositories;

namespace Users.API.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserCommandHandler(
        IUsersRepository usersRepository,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(command);

        var hashedPassword = _passwordHasher.HashPassword(user, command.Password);
        user.PasswordHash = hashedPassword;

        var addedUser = await _usersRepository.AddUserAsync(user, cancellationToken);

        return new CreateUserResponse
        {
            Id = addedUser.Id,
            Message = "User added successfully",
            Success = true
        };
    }
}
