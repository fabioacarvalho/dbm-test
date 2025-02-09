using Dbm.Core.Data.Contexts;

namespace Dbm.Core.Config;

public static class Databaseconfig
{
    public static void RegisterDatabase(this IServiceCollection services)
    {
        services.AddDbContext<DbmDbContext>();
    }
}