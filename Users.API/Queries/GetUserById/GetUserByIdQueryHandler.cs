using MediatR;
using Users.API.Models.Dto;
using Users.API.Services;

namespace Users.API.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserService _usersService;

    public GetUserByIdQueryHandler(IUserService usersService)
    {
        _usersService = usersService;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _usersService.GetUserByIdAsync(request.Id, cancellationToken);
    }
}
