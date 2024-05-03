using UserApp.Domain.Enums;
using UserApp.Service.DTOs.Assets;
using UserApp.Service.DTOs.Roles;

namespace UserApp.Service.DTOs.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public RoleViewModel Role { get; set; }
    public AssetViewModel Asset { get; set; }
}