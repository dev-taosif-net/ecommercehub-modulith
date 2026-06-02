using Carter;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogExtensions).Assembly);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

var app = builder.Build();

app.MapGroup("/api").MapCarter();
app.UseModules();
app.UseApiSwagger();

app.MapGet("/api/test", () => "Api is working.");

app.Run();