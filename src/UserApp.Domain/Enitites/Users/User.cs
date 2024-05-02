using UserApp.Domain.Enums;
using UserApp.Domain.Commons;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Domain.Enitites.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }
    public long? AssetId { get; set; }
    public Asset Asset { get; set; }
}