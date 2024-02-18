using MediatR;
using Users.API.Models.Responses;

namespace Users.API.Commands.CreateUser;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    string Password,
    int RoleId
    ) : IRequest<CreateUserResponse>;
