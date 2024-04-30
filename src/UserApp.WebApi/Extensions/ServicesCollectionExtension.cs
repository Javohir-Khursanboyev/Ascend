using UserApp.Data.UnitOfWorks;
using UserApp.Service.Configurations;
using UserApp.Service.Helpers;
using UserApp.Service.Services.Assets;
using UserApp.Service.Services.Users;
using UserApp.WebApi.Middlewares;

namespace UserApp.WebApi.Extensions;

public static class ServicesCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }

    public static void InjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
        //EnvironmentHelper.JWTKey = app.Configuration.GetSection("JWT:Key").Value;
        //EnvironmentHelper.TokenLifeTimeInHours = app.Configuration.GetSection("JWT:LifeTime").Value;
        //EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        //EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:Password").Value;
        //EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:Port").Value;
        //EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:Host").Value;
        var defaultParams = new PaginationParams(
            Convert.ToInt32(app.Configuration.GetSection("DefaultPaginationParams:PageIndex").Value), 
            Convert.ToInt32(app.Configuration.GetSection("DefaultPaginationParams:PageSize").Value));
    }
}