using UserApp.Service.DTOs.Roles;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Permissions;

namespace UserApp.Service.Services.Permissions;

public class PermissionService : IPermissionService
{
    public Task<RoleViewModel> CreateAsync(PermissionCreateModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RoleViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public Task<RoleViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<RoleViewModel> UpdateAsync(long id, PermissionUpdateModel model)
    {
        throw new NotImplementedException();
    }
}