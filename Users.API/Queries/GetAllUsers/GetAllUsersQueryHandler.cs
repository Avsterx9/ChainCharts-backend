using AutoMapper;
using MediatR;
using Users.API.Models.Dto;
using Users.API.Repositories;
using Users.API.Services;

namespace Users.API.Queries.GetAllUsers;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetAllUsersAsync(cancellationToken);
    }
}
