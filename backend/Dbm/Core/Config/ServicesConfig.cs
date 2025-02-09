using Dbm.Api.Products.Services;

namespace Dbm.Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}