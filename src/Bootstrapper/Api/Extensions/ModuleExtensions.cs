namespace Api.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddBasketModule(configuration)
            .AddCatalogModule(configuration)
            .AddOrderingModule(configuration);

        return services;
    }

    public static WebApplication UseModules(this WebApplication app)
    {
        app
            .UseBasketModule()
            .UseCatalogModule()
            .UseOrderingModule();

        return app;
    }
}

