using Carter;
using Shared.Extensions;

namespace Api.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCarterWithAssemblies(
                typeof(CatalogExtensions).Assembly,
                typeof(BasketExtensions).Assembly,
                typeof(OrderingExtensions).Assembly);

        services
            .AddBasketModule(configuration)
            .AddCatalogModule(configuration)
            .AddOrderingModule(configuration);

        return services;
    }

    public static WebApplication UseModules(this WebApplication app)
    {
        app.MapGroup("/api").MapCarterModules(
            ("catalog", typeof(CatalogExtensions).Assembly),
            ("basket",  typeof(BasketExtensions).Assembly),
            ("ordering", typeof(OrderingExtensions).Assembly));

        app
            .UseBasketModule()
            .UseCatalogModule()
            .UseOrderingModule();

        return app;
    }
}
