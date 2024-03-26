using MediatR;
using Users.API.Models.Dto;
using Users.API.Queries.GetUserById;
using Users.API.Services;

namespace Users.API.Queries.GetCurrentUser;

public sealed class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
{
    private readonly IUserService _usersService;

    public GetCurrentUserQueryHandler(IUserService usersService)
    {
        _usersService = usersService;
    }

    public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return await _usersService.GetCurrentUserAsync(cancellationToken);
    }
}
