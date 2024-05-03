using UserApp.Service.DTOs.Roles;
using UserApp.Service.DTOs.Permissions;

namespace UserApp.Service.DTOs.RolePermissions;

public class RolePermissionViewModel
{
    public long Id { get; set; }
    public RoleViewModel Role {  get; set; }
    public PermissionViewModel Permission    { get; set; }
}