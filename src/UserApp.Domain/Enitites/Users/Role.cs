using UserApp.Domain.Commons;

namespace UserApp.Domain.Enitites.Users;

public class Role:Auditable
{
    public string Name { get; set; }
}