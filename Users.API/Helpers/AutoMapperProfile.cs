using AutoMapper;
using Users.API.Commands.CreateUser;
using Users.API.Models.Dto;
using Users.API.Models.Entities;

namespace Users.API.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(x => x.Role, o => o.MapFrom(src => src.Role != null 
                ? new RoleDto(src.Role.Id, src.Role.Name)
                : null));

        CreateMap<CreateUserCommand, User>();
    }
}
