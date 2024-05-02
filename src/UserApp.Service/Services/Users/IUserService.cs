using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Assets;
using UserApp.Service.DTOs.Auths;
using UserApp.Service.DTOs.Users;

namespace UserApp.Service.Services.Users;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreateModel model);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model, bool isUsesDeleted = false);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    Task<UserViewModel> UploadPictureAsync(long id,AssetCreateModel picture);
    Task<UserViewModel> DeletePictureAsync(long id);
    Task<LoginViewModel> LoginAsync(LoginCreateModel login);
    Task<UserViewModel> ChangePasswordAsync(UserChangePasswordModel model);
}