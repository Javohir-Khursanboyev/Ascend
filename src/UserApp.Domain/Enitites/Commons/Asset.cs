using UserApp.Domain.Commons;
using UserApp.Domain.Enums;

namespace UserApp.Domain.Enitites.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public FileType FileType { get; set; }
}
