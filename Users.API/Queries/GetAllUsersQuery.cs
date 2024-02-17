using MediatR;
using Users.API.Models.Dto;

namespace Users.API.Queries;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;
