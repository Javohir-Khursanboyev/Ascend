using UserApp.Service.DTOs.Assets;

namespace UserApp.Service.Services.Assets;

public class AssetService : IAssetService
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<AssetViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<AssetViewModel> UploadAsync(AssetCreateModel model)
    {
        throw new NotImplementedException();
    }
}