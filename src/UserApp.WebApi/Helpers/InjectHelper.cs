using UserApp.Service.Services.RolePermissions;

namespace UserApp.WebApi.Helpers;

public class InjectHelper
{
    public static IRolePermissionService RolePermissionService { get; set; }
}