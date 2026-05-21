# Bootstrapper / API

## Purpose

The `Api` project is the **composition root** of the application. It has no business logic of its own — its sole responsibility is to wire up all modules and start the ASP.NET Core host.

## Project

`src/Bootstrapper/Api/Api.csproj`

## How It Works

### 1. Module Registration (DI)

Each module exposes an `IServiceCollection` extension method. `Program.cs` calls them all:

```csharp
builder.Services
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);
```

### 2. Module Pipeline Setup

Each module exposes an `IApplicationBuilder` extension method for middleware and endpoint mapping:

```csharp
app
    .UseBasketModule()
    .UseCatalogModule()
    .UseOrderingModule();
```

### 3. Global Usings

`GlobalUsings.cs` imports all module namespaces so `Program.cs` stays clean:

```csharp
global using Basket;
global using Catalog;
global using Ordering;
```

## Adding a New Module

1. Create a new class library under `src/Modules/{ModuleName}/`
2. Reference `Shared.csproj`
3. Implement `Add{ModuleName}Module` and `Use{ModuleName}Module` extension methods
4. Add a `<ProjectReference>` to `Api.csproj`
5. Add a `global using` in `GlobalUsings.cs`
6. Call both extension methods in `Program.cs`

