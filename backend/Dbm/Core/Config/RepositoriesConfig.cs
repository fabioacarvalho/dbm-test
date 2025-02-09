using Dbm.Core.Repositories.Products;

namespace Dbm.Core.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}