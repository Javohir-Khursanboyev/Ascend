using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Roles;

namespace UserApp.Service.Services.Roles;

public interface IRoleService
{
    Task<RoleViewModel> CreateAsync(RoleCreateModel model);
    Task<RoleViewModel> UpdateAsync(long id, RoleUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<RoleViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RoleViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}