using AutoMapper;
using Users.API.Models.Dto;
using Users.API.Models.Dto.Auth;
using Users.API.Models.Entities;

namespace Users.API.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Role, act => act.MapFrom(src => src.Role != null
                ? new RoleDto(src.RoleId, src.Role.Name)
                : null));

        CreateMap<UserRegistrationDto, User>();
        CreateMap<Role, RoleDto>();
    }
}
