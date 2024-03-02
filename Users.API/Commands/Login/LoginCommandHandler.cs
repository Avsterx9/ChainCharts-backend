using Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.API.Helpers;
using Users.API.Models.Entities;
using Users.API.Repositories;
using Users.API.Responses;

namespace Users.API.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthSettings _authSettings;

    public LoginCommandHandler(
        IUsersRepository usersRepository,
        IPasswordHasher<User> passwordHasher,
        IOptions<AuthSettings> authSettings)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _authSettings = authSettings.Value;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(ExceptionCodes.USER_NOT_FOUND);
        }

        var passwordValidation = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

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

        return new LoginResponse(tokenHandler.WriteToken(token));
    }
}
