using Users.API.Models.Database;
using Users.API.Models.Entities;

namespace Users.API.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UsersContext _context;

    public UsersRepository(UsersContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return new List<User>();
    }
}
