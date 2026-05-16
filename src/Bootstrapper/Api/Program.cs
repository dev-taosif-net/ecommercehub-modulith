using Basket;
using Catalog;
using Ordering;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapGet("/", () => "Api is working.");

app.Run();