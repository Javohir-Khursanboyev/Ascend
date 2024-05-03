using UserApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApp.Service.DTOs.Users;
using UserApp.Service.DTOs.Assets;
using UserApp.Service.Configurations;
using UserApp.Service.Services.Users;
using Microsoft.AspNetCore.Authorization;

namespace UserApp.WebApi.Controllers;

public class UsersController(IUserService userService) : BaseController
{
    [AllowAnonymous]
    [HttpPost()]
    public async Task<IActionResult> PostAsync(UserCreateModel userCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.CreateAsync(userCreateModel)
        });
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, UserUpdateModel userUpdateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UpdateAsync(id, userUpdateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetByIdAsync(id)
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
            Data = await userService.GetAllAsync(@params, filter, search)
        });
    }

    [HttpPost("{id:long}/pictures/upload")]
    public async Task<IActionResult> PictureUploadAsync(long id,AssetCreateModel asset)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UploadPictureAsync(id, asset)
        });
    }

    [HttpPost("{id:long}/pictures/delete")]
    public async Task<IActionResult> PictureDeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.DeletePictureAsync(id)
        });
    }

    [HttpPatch("{id:long}/change-password")]
    public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordModel model)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.ChangePasswordAsync(model)
        });
    }
}
