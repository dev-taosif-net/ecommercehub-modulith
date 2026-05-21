# Shared Kernel

## Purpose

The `Shared` project is the **shared kernel** of the solution. It contains abstractions, contracts, and utilities that are used by all modules — but **no business logic**.

## Project

`src/Shared/Shared/Shared.csproj`

## NuGet Dependencies

| Package | Purpose |
|---|---|
| `Microsoft.AspNetCore.Http.Abstractions` | `HttpContext`, `IMiddleware`, etc. |
| `Microsoft.Extensions.Configuration.Abstractions` | `IConfiguration` for module config |
| `Microsoft.Extensions.DependencyInjection.Abstractions` | `IServiceCollection` for module registration |

## What Belongs Here

✅ **Put in Shared:**
- Interface contracts used across modules (e.g. `ICurrentUser`, `IDateTimeProvider`)
- Shared value objects (e.g. `Money`, `Address`)
- Base classes / markers (e.g. `IDomainEvent`, `IEntity`)
- Common extension methods
- Cross-cutting utilities (e.g. pagination helpers)

❌ **Do NOT put in Shared:**
- Business logic specific to a module
- Module-specific entities or aggregates
- Infrastructure concerns (DB contexts, HTTP clients)

## Rules

- All modules reference `Shared`; `Shared` references **no module**
- Keep `Shared` lean — prefer duplication in modules over wrong abstractions here

