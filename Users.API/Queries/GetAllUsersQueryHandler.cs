using AutoMapper;
using MediatR;
using Users.API.Models.Dto;
using Users.API.Repositories;

namespace Users.API.Queries;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _usersRepository.GetAllUsersAsync(cancellationToken);

        return users.Select(x => _mapper.Map<UserDto>(x)).ToList();
    }
}
