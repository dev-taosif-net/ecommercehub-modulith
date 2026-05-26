using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Infrastructure.Seed;

namespace Shared.Infrastructure.Extensions;

public static class SeederExtensions
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        var services = app.ApplicationServices;
        var logger   = services.GetRequiredService<ILoggerFactory>()
                               .CreateLogger(nameof(SeederExtensions));

        try
        {
            logger.LogInformation("Seeding database…");

            using var scope  = services.CreateScope();
            var seeders      = scope.ServiceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
                seeder.SeedAsync().GetAwaiter().GetResult();

            logger.LogInformation("Database seeding completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }

        return app;
    }
}

