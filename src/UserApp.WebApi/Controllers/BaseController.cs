using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{

}