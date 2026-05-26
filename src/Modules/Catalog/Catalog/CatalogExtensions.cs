using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Extensions;

namespace Catalog;

public static class CatalogExtensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        //Add Infrastructure Services
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<CatalogDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        //Use Infrastructure Services
        app.MigrateDatabase<CatalogDbContext>();

        return app;
    }
}