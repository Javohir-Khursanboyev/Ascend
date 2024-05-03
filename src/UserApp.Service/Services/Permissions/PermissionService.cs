using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApp.Data.UnitOfWorks;
using UserApp.Domain.Enitites.Users;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Permissions;
using UserApp.Service.Exceptions;
using UserApp.Service.Extensions;

namespace UserApp.Service.Services.Permissions;

public class PermissionService(
    IMapper mapper,
    IUnitOfWork unitOfWork) : IPermissionService
{
    public async Task<PermissionViewModel> CreateAsync(PermissionCreateModel model)
    {
        var existPermission = await unitOfWork.Permissions.
            SelectAsync(p => p.Action.ToLower() == model.Action.ToLower() && p.Controller.ToLower() == model.Controller.ToLower());

        if (existPermission is not null)
            throw new AlreadyExistException("Permission is already exist");

        var permission = mapper.Map<Permission>(model);
        permission.Create();
        var createdPermission = await unitOfWork.Permissions.InsertAsync(permission);
        await unitOfWork.SaveAsync();

        return mapper.Map<PermissionViewModel>(createdPermission);
    }

    public async Task<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel model)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(p => p.Id == id)
            ?? throw new NotFoundException("Permission is not found");

        var elreadyExistPermission = await unitOfWork.Permissions.
            SelectAsync(p => p.Action.ToLower() == model.Action.ToLower() && p.Controller.ToLower() == model.Controller.ToLower() && p.Id != id);

        mapper.Map(model, existPermission);
        existPermission.Update();
        var updatePermission = await unitOfWork.Permissions.UpdateAsync(existPermission); 
        await unitOfWork.SaveAsync();

        return mapper.Map<PermissionViewModel> (updatePermission);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(p => p.Id == id)
            ?? throw new NotFoundException("Permission is not found");

        await unitOfWork.Permissions.DropAsync(existPermission);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async Task<PermissionViewModel> GetByIdAsync(long id)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(expression: p => p.Id == id, isTracked : false)
           ?? throw new NotFoundException("Permission is not found");

        return mapper.Map<PermissionViewModel> (existPermission);
    }

    public async Task<IEnumerable<PermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var permissions = unitOfWork.Permissions.SelectAsQueryable(isTracked: false).OrderBy(filter);

        if(!string.IsNullOrEmpty(search))
            permissions = permissions.Where(p => 
            p.Action.ToLower().Contains(search.ToLower()) ||
            p.Controller.ToLower().Contains(search.ToLower()));

        var paginatePermission = await permissions.ToPaginateAsQueryable(@params).ToListAsync();
        return mapper.Map<IEnumerable<PermissionViewModel>> (paginatePermission);
    }
}