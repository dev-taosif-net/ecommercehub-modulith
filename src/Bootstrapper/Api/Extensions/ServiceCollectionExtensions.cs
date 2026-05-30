namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddBasketModule(configuration)
            .AddCatalogModule(configuration)
            .AddOrderingModule(configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
            {
                Title = "EcommerceHub Modulith API",
                Version = "v1",
                Description = "API documentation for EcommerceHub Modulith application.",
                Contact = new Microsoft.OpenApi.OpenApiContact
                {
                    Name = "EcommerceHub Team"
                }
            });
        });

        return services;
    }
}

