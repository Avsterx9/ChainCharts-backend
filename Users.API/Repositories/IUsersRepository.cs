using Users.API.Commands.CreateUser;
using Users.API.Models.Entities;
using Users.API.Models.Responses;

namespace Users.API.Repositories;
public interface IUsersRepository
{
    Task<List<User>> GetAllUsersAsync(CancellationToken ct);
    Task<CreateUserResponse> CreateUserAsync(CreateUserCommand command, CancellationToken ct);
}