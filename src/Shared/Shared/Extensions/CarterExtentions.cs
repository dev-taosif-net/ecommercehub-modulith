using System.Reflection;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions;

public static class CarterExtentions
{
    public static IServiceCollection AddCarterWithAssemblies
        (this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddCarter(configurator: config =>
        {
            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes()
                    .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();

                config.WithModules(modules);
            }
        });

        return services;
    }

    /// <summary>
    /// Maps Carter modules grouped by module name: /api/{moduleName}/...
    /// </summary>
    public static IEndpointRouteBuilder MapCarterModules(
        this IEndpointRouteBuilder app,
        params (string ModulePrefix, Assembly Assembly)[] modules)
    {
        foreach (var (modulePrefix, assembly) in modules)
        {
            var group = app.MapGroup(modulePrefix);

            var moduleTypes = assembly.GetTypes()
                .Where(t => typeof(ICarterModule).IsAssignableFrom(t)
                            && !t.IsAbstract
                            && !t.IsInterface);

            foreach (var moduleType in moduleTypes)
            {
                var carterModule = (ICarterModule)ActivatorUtilities
                    .CreateInstance(app.ServiceProvider, moduleType);

                carterModule.AddRoutes(group);
            }
        }

        return app;
    }
}