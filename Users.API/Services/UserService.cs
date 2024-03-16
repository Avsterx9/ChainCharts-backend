using AutoMapper;
using Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.API.Helpers;
using Users.API.Models.Dto;
using Users.API.Models.Dto.Auth;
using Users.API.Models.Entities;
using Users.API.Repositories;

namespace Users.API.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthSettings _authSettings;
    private readonly IMapper _mapper;

    public UserService(
        IUsersRepository usersRepository,
        IPasswordHasher<User> passwordHasher,
        IOptions<AuthSettings> authSettings,
        IMapper mapper)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _authSettings = authSettings.Value;
        _mapper = mapper;
    }

    public async Task<string> GenerateJwtTokenAsync(UserCredentialsDto UserCredentials, CancellationToken ct)
    {
        var user = await _usersRepository.GetUserByEmailAsync(UserCredentials.Email, ct);

        if (user is null)
        {
            throw new NotFoundException(ExceptionCodes.USER_NOT_FOUND);
        }

        var passwordValidation = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, UserCredentials.Password);

        if (passwordValidation == PasswordVerificationResult.Failed)
            throw new BadRequestException(ExceptionCodes.BAD_EMAIL_OR_PASSWORD);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role, $"{user.Role.Name}")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authSettings.JwtIssuer,
            _authSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _usersRepository.GetAllUsersAsync(cancellationToken);

        return users.Select(user => _mapper.Map<UserDto>(user));
    }

    public async Task<UserDto> CreateUserAsync(UserRegistrationDto RegistrationDto, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(RegistrationDto);

        var hashedPassword = _passwordHasher.HashPassword(user, RegistrationDto.Password);
        user.PasswordHash = hashedPassword;

        var addedUser = await _usersRepository.AddUserAsync(user, cancellationToken);

        return _mapper.Map<UserDto>(addedUser);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserByIdAsync(Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(ExceptionCodes.USER_NOT_FOUND);
        }

        return _mapper.Map<UserDto>(user);
    }
}
