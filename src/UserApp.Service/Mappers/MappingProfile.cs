using AutoMapper;
using UserApp.Service.DTOs.Users;
using UserApp.Service.DTOs.Assets;
using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetViewModel, Asset>().ReverseMap();

        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();
    }
}