using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Shared.Infrastructure.Extensions;

public static class MigrationExtensions
{
    public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app)
        where TContext : DbContext
    {
        var services  = app.ApplicationServices;
        var logger    = services.GetRequiredService<ILoggerFactory>()
                                .CreateLogger(typeof(TContext).Name);
        var contextName = typeof(TContext).Name;

        try
        {
            logger.LogInformation("Applying database migrations for {DbContext}…", contextName);

            using var scope   = services.CreateScope();
            var context       = scope.ServiceProvider.GetRequiredService<TContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();

            logger.LogInformation("Database migrations applied successfully for {DbContext}.", contextName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database for {DbContext}.", contextName);
            throw;
        }

        return app;
    }
}