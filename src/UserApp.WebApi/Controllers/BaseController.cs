using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApp.WebApi.Services;

namespace UserApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[CustomAuthorize]
public class BaseController : ControllerBase
{

}