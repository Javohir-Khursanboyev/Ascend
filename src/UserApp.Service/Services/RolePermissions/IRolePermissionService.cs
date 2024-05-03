using UserApp.Service.Configurations;
using UserApp.Service.DTOs.RolePermissions;

namespace UserApp.Service.Services.RolePermissions;

public interface IRolePermissionService
{
    Task<RolePermissionViewModel> CreateAsync(RolePermissionCreateModel model);
    Task<RolePermissionViewModel> UpdateAsync(long id, RolePermissionUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<RolePermissionViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RolePermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}