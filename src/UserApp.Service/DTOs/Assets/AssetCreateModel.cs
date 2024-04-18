using Microsoft.AspNetCore.Http;
using UserApp.Domain.Enums;

namespace UserApp.Service.DTOs.Assets;

public class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}
