using Users.API.Commands.CreateUser;
using Users.API.Models.Entities;
using Users.API.Models.Responses;
using Users.API.Queries.GetUserById;

namespace Users.API.Repositories;
public interface IUsersRepository
{
    Task<List<User>> GetAllUsersAsync(CancellationToken ct);
    Task<User> AddUserAsync(User user, CancellationToken ct);
    Task<User?> GetUserByIdAsync(Guid Id, CancellationToken cancellationToken);
}