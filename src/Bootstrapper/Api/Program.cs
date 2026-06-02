using Carter;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogExtensions).Assembly);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

var app = builder.Build();

app.MapCarter();

app.UseApiSwagger();
app.UseModules();

app.MapGet("/Test", () => "Api is working.");

app.Run();