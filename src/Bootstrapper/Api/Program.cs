using Carter;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCarterWithAssemblies(
        typeof(CatalogExtensions).Assembly,
        typeof(BasketExtensions).Assembly,
        typeof(OrderingExtensions).Assembly);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

var app = builder.Build();

app.MapGroup("/api").MapCarterModules(
    ("catalog", typeof(CatalogExtensions).Assembly),
    ("basket",  typeof(BasketExtensions).Assembly),
    ("ordering", typeof(OrderingExtensions).Assembly));

app.UseModules();
app.UseApiSwagger();

app.MapGet("/api/test", () => "Api is working.");

app.Run();