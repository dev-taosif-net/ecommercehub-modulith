# Catalog Module

## Responsibility

The **Catalog** module manages the product catalogue — products, categories, pricing, and inventory availability.

## Project

`src/Modules/Catalog/Catalog/Catalog.csproj`

## Registration

The module is registered in `Program.cs` via extension methods:

```csharp
// Service registration
builder.Services.AddCatalogModule(builder.Configuration);

// Middleware / endpoint registration
app.UseCatalogModule();
```

## Configuration

```json
{
  "CatalogModule": {
    "ConnectionString": "..."
  }
}
```

## Planned Features

- [ ] List products
- [ ] Get product by ID
- [ ] Create / update / delete product
- [ ] Product categories
- [ ] Search & filtering

## Domain Concepts

| Concept | Description |
|---|---|
| `Product` | A sellable item with name, description, price, and stock |
| `Category` | A grouping of related products |

## Endpoints

> _To be documented as endpoints are implemented._

## Dependencies

- `Shared` — shared abstractions

