using AutoMapper;
using Users.API.Commands.CreateUser;
using Users.API.Models.Dto;
using Users.API.Models.Entities;

namespace Users.API.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserCommand, User>();
    }
}
