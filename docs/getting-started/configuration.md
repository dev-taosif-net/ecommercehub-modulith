# Configuration

## Configuration Files

| File | Purpose |
|---|---|
| `appsettings.json` | Base configuration (all environments) |
| `appsettings.Development.json` | Overrides for local development |

Both files are located in `src/Bootstrapper/Api/`.

## Environment Variables

ASP.NET Core reads environment variables following the pattern `SectionName__Key`.

Example:
```powershell
$env:ConnectionStrings__DefaultConnection = "Host=localhost;Database=ecommercehub"
```

## Adding Module-Specific Configuration

Each module receives `IConfiguration` via its `Add{Module}Module(configuration)` extension method. Add module-specific config sections under a named key:

```json
{
  "CatalogModule": {
    "ConnectionString": "..."
  },
  "BasketModule": {
    "RedisConnection": "..."
  },
  "OrderingModule": {
    "ConnectionString": "..."
  }
}
```

