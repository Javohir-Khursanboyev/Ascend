using UserApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.RolePermissions;
using UserApp.Service.Services.RolePermissions;

namespace UserApp.WebApi.Controllers;

public class RolePermissionsController(IRolePermissionService rolePermissionService) : BaseController
{
    [HttpPost()]
    public async Task<IActionResult> PostAsync(RolePermissionCreateModel rolePermissionCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await rolePermissionService.CreateAsync(rolePermissionCreateModel)
        });
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, RolePermissionUpdateModel rolePermissionUpdateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await rolePermissionService.UpdateAsync(id, rolePermissionUpdateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await rolePermissionService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await rolePermissionService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await rolePermissionService.GetAllAsync(@params, filter, search)
        });
    }
}