using Dbm.Api.Products.Dtos;
using Dbm.Api.Products.Validators;
using FluentValidation;

namespace Dbm.Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<ProductRequest>, ProductRequestValidator>();
    }
}