using AutoMapper;
using UserApp.Service.DTOs.Users;
using UserApp.Service.DTOs.Roles;
using UserApp.Service.DTOs.Assets;
using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;
using UserApp.Service.DTOs.Permissions;
using UserApp.Service.DTOs.RolePermissions;

namespace UserApp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetViewModel, Asset>().ReverseMap();

        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();

        CreateMap<Role, RoleCreateModel>().ReverseMap();
        CreateMap<Role, RoleUpdateModel>().ReverseMap();
        CreateMap<RoleViewModel, Role>().ReverseMap();

        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();
        CreateMap<PermissionViewModel, Permission>().ReverseMap();

        CreateMap<RolePermission, RolePermissionCreateModel>().ReverseMap();
        CreateMap<RolePermission, RolePermissionUpdateModel>().ReverseMap();
        CreateMap<RolePermissionViewModel, RolePermission>().ReverseMap();
    }
}