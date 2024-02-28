using AutoMapper;
using MediatR;
using Users.API.Models.Dto;
using Users.API.Repositories;

namespace Users.API.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserByIdAsync(request.Id, cancellationToken);

        if(user is null)
        {
            //throw Exception.
        }

        return _mapper.Map<UserDto>(user);
    }
}
