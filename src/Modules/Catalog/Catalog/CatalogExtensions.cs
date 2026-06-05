using System.Reflection;
using Catalog.Persistence.Seed;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(Shared.Behaviors.ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(Shared.Behaviors.LoggingBehavior<,>));
            }
        );

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //Add Persistence Services
        var connectionString = configuration.GetConnectionString("Database")
                               ?? throw new InvalidOperationException(
                                   "Connection string 'Database' is not configured.");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<CatalogDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IDataSeeder, CatalogDataSeeder>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        //Use Persistence Services
        app.MigrateDatabase<CatalogDbContext>();
        app.SeedDatabase();

        return app;
    }
}