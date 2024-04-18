using UserApp.Data.UnitOfWorks;
using UserApp.Service.Services.Assets;

namespace UserApp.WebApi.Extensions;

public static class ServicesCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAssetService, AssetService>();
    }

    //public static void AddExceptionHandlers(this IServiceCollection services)
    //{
    //    services.AddExceptionHandler<NotFoundExceptionHandler>();
    //    services.AddExceptionHandler<AlreadyExistExceptionHandler>();
    //    services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
    //    services.AddExceptionHandler<CustomExceptionHandler>();
    //    services.AddExceptionHandler<InternalServerExceptionHandler>();
    //}
}