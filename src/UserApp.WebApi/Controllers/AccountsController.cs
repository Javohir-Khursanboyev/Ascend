using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApp.Service.DTOs.Auths;
using UserApp.Service.Services.Users;
using UserApp.WebApi.Models;

namespace UserApp.WebApi.Controllers;

public class AccountsController(IUserService userService):ControllerBase
{
    [AllowAnonymous]
    [HttpGet("login")]
    public async Task<IActionResult> LoginAsync(LoginCreateModel createModel)
    {
        return Ok(new Response
        { 
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.LoginAsync(createModel)
        });
    }
}