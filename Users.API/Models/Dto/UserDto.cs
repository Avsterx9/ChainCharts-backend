namespace Users.API.Models.Dto;

public record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    int RoleId
    );
