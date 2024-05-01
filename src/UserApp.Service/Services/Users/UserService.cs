using AutoMapper;
using UserApp.Service.Helpers;
using UserApp.Data.UnitOfWorks;
using UserApp.Service.Extensions;
using UserApp.Service.DTOs.Users;
using UserApp.Service.Exceptions;
using UserApp.Domain.Enitites.Users;
using UserApp.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using UserApp.Service.DTOs.Assets;
using UserApp.Service.Services.Assets;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Service.Services.Users;

public class UserService(IMapper mapper, IUnitOfWork unitOfWork, IAssetService assetService) : IUserService
{
    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Email == model.Email);
        
        if(existUser is not null && existUser.IsDeleted)
            return await UpdateAsync(existUser.Id, mapper.Map<UserUpdateModel>(model), true);

        else if (existUser is not null && !existUser.IsDeleted)
            throw new AlreadyExistException("User is already exist");

        var mapperUser = mapper.Map<User>(model);
        mapperUser.Password = PasswordHasher.Hash(model.Password);
        mapperUser.Create();
        var createdUser = await unitOfWork.Users.InsertAsync(mapperUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model, bool isUsesDeleted = false)
    {
        var existUser = new User();
        if (isUsesDeleted)
            existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id);
        else
            existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id && !u.IsDeleted)
                ?? throw new NotFoundException("User is not found");

        var alreadyExistUser = await unitOfWork.Users.SelectAsync(u => u.Email == model.Email && !u.IsDeleted && u.Id != id);
        if (alreadyExistUser is not null)
            throw new AlreadyExistException("User is already exist");

        mapper.Map(model, existUser);
        existUser.Update();
        var updateModel = await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel> (updateModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == id && !user.IsDeleted)
            ?? throw new NotFoundException("User is not found");

        existUser.Delete();
        await unitOfWork.Users.DeleteAsync(existUser);
        return true;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(expression: u => u.Id == id && !u.IsDeleted, includes: ["Asset"], isTracked:false)
            ?? throw new NotFoundException("User is not found");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var users = unitOfWork.Users.
            SelectAsQueryable(expression: u => !u.IsDeleted, includes: ["Asset"], isTracked:false).
            OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            users = users.Where(p =>
             p.FirstName.ToLower().Contains(search.ToLower()) ||
             p.LastName.ToLower().Contains(search.ToLower()));

        var paginateUsers = await users.ToPaginateAsQueryable(@params).ToListAsync();
        return mapper.Map<IEnumerable<UserViewModel>>(paginateUsers);   
    }

    public async Task<UserViewModel> UploadPictureAsync(long id,AssetCreateModel picture)
    {
        await unitOfWork.BeginTransactionAsync();
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id && !u.IsDeleted, ["Asset"])
            ?? throw new NotFoundException("User is not found");

        var createdPicture = await assetService.UploadAsync(picture);
        existUser.Update();
        existUser.AssetId = createdPicture.Id;
        existUser.Asset = mapper.Map<Asset>(createdPicture);
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<UserViewModel> DeletePictureAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id && !u.IsDeleted, ["Asset"])
            ?? throw new NotFoundException("User is not found");

        await assetService.DeleteAsync(Convert.ToInt64(existUser.AssetId));
        existUser.AssetId = null;
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return mapper.Map<UserViewModel>(existUser);
    }
}