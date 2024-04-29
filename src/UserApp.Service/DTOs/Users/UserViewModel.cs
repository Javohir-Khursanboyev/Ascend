using UserApp.Domain.Enums;
using UserApp.Service.DTOs.Assets;

namespace UserApp.Service.DTOs.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public AssetViewModel Asset { get; set; }
}