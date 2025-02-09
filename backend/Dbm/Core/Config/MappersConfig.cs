using Dbm.Api.Products.Mappers;

namespace Dbm.Core.Config;

public static class MappersConfig
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IProductMapper, ProductMapper>();
        }
    }