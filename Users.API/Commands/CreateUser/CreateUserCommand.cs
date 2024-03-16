using MediatR;
using Users.API.Models.Dto.Auth;
using Users.API.Models.Responses;

namespace Users.API.Commands.CreateUser;

public record CreateUserCommand(UserRegistrationDto RegistrationDto) : IRequest<CreateUserResponse>;
