using Shared.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.UseModules();
app.UseApiSwagger();

app.UseExceptionHandler(options => { });

app.MapGet("/api/test", () => "Api is working.");

app.Run();