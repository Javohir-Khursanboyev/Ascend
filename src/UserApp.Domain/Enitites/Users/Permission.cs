using UserApp.Domain.Commons;

namespace UserApp.Domain.Enitites.Users;

public class Permission : Auditable
{
    public string Action { get; set; }
    public string Controller { get; set; }
}