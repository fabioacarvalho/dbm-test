using Microsoft.OpenApi.Models;

namespace Dbm.Core.Config;

public static class DocumentationConfig
{
    public static void RegisterDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(option => 
        {
            option.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Version = "v1",
                Title = "Dbm API",
                Description = "API developed for Dbm test.",
                Contact = new OpenApiContact
                {
                    Name = "Fábio A. Carvalho - LinkedIn",
                    Url = new Uri("https://linkedin.com/in/fabioacarvalho")
                }
            });
        });
    }
}