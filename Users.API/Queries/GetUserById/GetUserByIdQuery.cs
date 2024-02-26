using MediatR;
using Users.API.Models.Dto;

namespace Users.API.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;
