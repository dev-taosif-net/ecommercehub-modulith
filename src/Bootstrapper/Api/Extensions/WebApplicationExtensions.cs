namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiPipeline(this WebApplication app)
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

        app
            .UseBasketModule()
            .UseCatalogModule()
            .UseOrderingModule();

        return app;
    }
}

