using Microsoft.EntityFrameworkCore;
using Users.API.Commands.CreateUser;
using Users.API.Models.Database;
using Users.API.Models.Entities;
using Users.API.Models.Responses;

namespace Users.API.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UsersContext _context;

    public UsersRepository(UsersContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync(CancellationToken ct)
    {
        return await _context.Users
            .Include(x => x.Role)
            .ToListAsync(ct);
    }

    public Task<CreateUserResponse> CreateUserAsync(CreateUserCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
