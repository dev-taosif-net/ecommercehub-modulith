var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "EcommerceHub Modulith API",
        Version = "v1",
        Description = "API documentation for EcommerceHub Modulith application.",
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "EcommerceHub Team"
        }
    });
});

var app = builder.Build();

//Configure the HTTP request pipeline.

app
    .UseBasketModule()
    .UseCatalogModule()
    .UseOrderingModule();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceHub Modulith API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/", () => "Api is working.");

app.Run();