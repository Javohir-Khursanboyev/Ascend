using AutoMapper;
using UserApp.Service.Helpers;
using UserApp.Data.UnitOfWorks;
using UserApp.Service.Extensions;
using UserApp.Service.Exceptions;
using UserApp.Service.DTOs.Assets;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Service.Services.Assets;

public class AssetService(IMapper mapper, IUnitOfWork unitOfWork) : IAssetService
{
    public async Task<AssetViewModel> UploadAsync(AssetCreateModel model)
    {
        var assetData = await FileHelper.CreateFileAsync(model.File, model.FileType);
        var asset = new Asset()
        {
            Name = assetData.Name,
            Path = assetData.Path,
        };

        asset.Create();
        var createdAsset = await unitOfWork.Assets.InsertAcync(asset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAcync(id)
            ?? throw new NotFoundException("Asset is not found");

        await unitOfWork.Assets.DropAcync(existAsset);
        await unitOfWork.SaveAsync(); 
        
        return true;
    }

    public async Task<AssetViewModel> GetByIdAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAcync(id)
           ?? throw new NotFoundException("Asset is not found");

        return mapper.Map<AssetViewModel>(existAsset);
    }
}