using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Users;

namespace UserApp.Service.Services.Users;

public interface IUserService
{
    ValueTask<UserViewModel> CreateAsync(UserCreateModel model);
    ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
