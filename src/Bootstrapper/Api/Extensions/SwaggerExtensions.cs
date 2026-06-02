namespace Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddApiSwagger(this IServiceCollection services)
    {
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

    public static WebApplication UseApiSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceHub Modulith API v1");
                options.RoutePrefix = string.Empty;
            });
        }

        return app;
    }
}

