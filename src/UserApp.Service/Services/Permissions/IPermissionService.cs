using UserApp.Service.DTOs.Roles;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Permissions;

namespace UserApp.Service.Services.Permissions;

public interface IPermissionService
{
    Task<RoleViewModel> CreateAsync(PermissionCreateModel model);
    Task<RoleViewModel> UpdateAsync(long id, PermissionUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<RoleViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RoleViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}