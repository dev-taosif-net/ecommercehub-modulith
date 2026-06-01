var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiPipeline();

app.MapGet("/Test", () => "Api is working.");

app.Run();