using Users.API.Models.Dto;
using Users.API.Models.Dto.Auth;

namespace Users.API.Services;
public interface IUserService
{
    Task<string> GenerateJwtTokenAsync(UserCredentialsDto UserCredentials, CancellationToken ct);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken CancellationToken);
    Task<UserDto> CreateUserAsync(UserRegistrationDto RegistrationDto, CancellationToken CancellationToken);
    Task<UserDto> GetUserByIdAsync(Guid Id, CancellationToken CancellationToken);
    Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
}