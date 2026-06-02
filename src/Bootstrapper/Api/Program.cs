var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

var app = builder.Build();

app.UseApiSwagger();
app.UseModules();

app.MapGet("/Test", () => "Api is working.");

app.Run();