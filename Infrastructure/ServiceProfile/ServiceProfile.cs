using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.ServiceProfile
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<RoleDto,Role>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<UserLogin,UserLoginDto>().ReverseMap();
            CreateMap<UserRole,UserRoleDto>().ReverseMap();
            CreateMap<Permission,PermissionDto>().ReverseMap();
            CreateMap<RolePermission,RolePermissionDto>().ReverseMap();
           
        }
    }
}