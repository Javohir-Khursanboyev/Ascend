using Microsoft.AspNetCore.Mvc;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Permissions;
using UserApp.Service.Services.Permissions;
using UserApp.WebApi.Models;

namespace UserApp.WebApi.Controllers;

public class PermissionsController(IPermissionService permissionService) : BaseController
{
    [HttpPost()]
    public async Task<IActionResult> PostAsync(PermissionCreateModel permissionCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await permissionService.CreateAsync(permissionCreateModel)
        });
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, PermissionUpdateModel permissionUpdateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await permissionService.UpdateAsync(id, permissionUpdateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await permissionService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await permissionService.GetByIdAsync(id)
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
            Data = await permissionService.GetAllAsync(@params, filter, search)
        });
    }
}
