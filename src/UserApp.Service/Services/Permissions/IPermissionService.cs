using UserApp.Service.DTOs.Roles;
using UserApp.Service.Configurations;

namespace UserApp.Service.Services.Permissions;

public interface IPermissionService
{
    Task<RoleViewModel> CreateAsync(RoleCreateModel model);
    Task<RoleViewModel> UpdateAsync(long id, RoleUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<RoleViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RoleViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}