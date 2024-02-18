using MediatR;
using Users.API.Models.Entities;
using Users.API.Models.Responses;
using Users.API.Repositories;

namespace Users.API.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUsersRepository _usersRepository;

    public CreateUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //var user = new User
        //{
            
        //}

        return new CreateUserResponse();
    }
}
