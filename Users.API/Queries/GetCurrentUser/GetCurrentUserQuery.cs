using MediatR;
using Users.API.Models.Dto;

namespace Users.API.Queries.GetCurrentUser;

public record GetCurrentUserQuery : IRequest<UserDto>;
