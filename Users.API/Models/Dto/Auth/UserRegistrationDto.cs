namespace Users.API.Models.Dto.Auth;

public record UserRegistrationDto(
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    string Password,
    int RoleId
    );
