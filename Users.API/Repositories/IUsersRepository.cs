using Users.API.Models.Entities;

namespace Users.API.Repositories;
public interface IUsersRepository
{
    Task<List<User>> GetAllUsers();
}