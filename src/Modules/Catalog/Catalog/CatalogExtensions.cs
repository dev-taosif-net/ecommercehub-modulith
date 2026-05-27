using Catalog.Persistence;
using Catalog.Persistence.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Persistence.Extensions;
using Shared.Persistence.Interceptors;
using Shared.Persistence.Seed;

namespace Catalog;

public static class CatalogExtensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        //Add Infrastructure Services
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseNpgsql(connectionString);
        });
        
        services.AddScoped<IDataSeeder, CatalogDataSeeder>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        //Use Infrastructure Services
        app.MigrateDatabase<CatalogDbContext>();
        app.SeedDatabase();

        return app;
    }
}