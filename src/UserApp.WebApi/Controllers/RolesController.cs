using Microsoft.AspNetCore.Mvc;
using UserApp.Service.Configurations;
using UserApp.Service.DTOs.Roles;
using UserApp.Service.Services.Roles;
using UserApp.WebApi.Models;

namespace UserApp.WebApi.Controllers;

public class RolesController(IRoleService roleService) : BaseController
{
    [HttpPost()]
    public async Task<IActionResult> PostAsync(RoleCreateModel roleCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.CreateAsync(roleCreateModel)
        });
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, RoleUpdateModel roleUpdateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.UpdateAsync(id, roleUpdateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.GetByIdAsync(id)
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
            Data = await roleService.GetAllAsync(@params, filter, search)
        });
    }
}
