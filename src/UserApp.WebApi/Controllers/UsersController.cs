using Microsoft.AspNetCore.Mvc;
using UserApp.Service.DTOs.Users;
using UserApp.Service.Services.Users;
using UserApp.WebApi.Models;

namespace UserApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : Controller
{
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
}
