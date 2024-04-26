using AutoMapper;
using UserApp.Data.UnitOfWorks;
using UserApp.Service.Extensions;
using UserApp.Service.DTOs.Users;
using UserApp.Service.Exceptions;
using UserApp.Domain.Enitites.Users;
using UserApp.Service.Configurations;

namespace UserApp.Service.Services.Users;

public class UserService(IMapper mapper, IUnitOfWork unitOfWork) : IUserService
{
    public async ValueTask<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Email == model.Email);

        if(existUser is not null)
        {
            if (existUser.IsDeleted)
                return await UpdateAsync(existUser.Id, mapper.Map<UserUpdateModel>(model));

            throw new AlreadyExistException("User is already exist");
        }

        var mapperUser = mapper.Map<User>(model);
        mapperUser.Create();
        var createdUser = await unitOfWork.Users.InsertAsync(mapperUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel model)
    {
        throw new NotImplementedException();
    }
}