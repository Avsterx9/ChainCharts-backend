using MediatR;
using Users.API.Models.Dto;

namespace Users.API.Queries.GetAllUsers;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;
