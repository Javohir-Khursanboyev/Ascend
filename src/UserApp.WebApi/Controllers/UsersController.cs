using Microsoft.AspNetCore.Mvc;
using UserApp.Service.DTOs.Users;
using UserApp.Service.Services.Users;
using UserApp.WebApi.Models;

namespace UserApp.WebApi.Controllers;

public class UsersController(IUserService userService) : Controller
{
    [HttpPost()]
    public async ValueTask<IActionResult> PictureUploadAsync(UserCreateModel userCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.CreateAsync(userCreateModel)
        });
    }
}
