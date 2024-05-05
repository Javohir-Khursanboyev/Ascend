using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using UserApp.Service.Services.RolePermissions;
using UserApp.WebApi.Helpers;

namespace UserApp.WebApi.Services;

public class CustomAuthorize : Attribute, IAuthorizationFilter
{
    private readonly IRolePermissionService rolePermissionService;
    public CustomAuthorize()
    {
        rolePermissionService = InjectHelper.RolePermissionService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        var actionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
        var action = actionDescriptor.ActionName;
        var controller = actionDescriptor.ControllerName;
        var role = context.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (!rolePermissionService.CheckRolePermission(role, action, controller))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }
    }
}