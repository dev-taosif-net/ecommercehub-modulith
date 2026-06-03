var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddModules(builder.Configuration)
    .AddApiSwagger();

var app = builder.Build();

app.UseModules();
app.UseApiSwagger();

app.MapGet("/api/test", () => "Api is working.");

app.Run();