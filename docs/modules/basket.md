# Basket Module

## Responsibility

The **Basket** module manages a customer's shopping cart — adding/removing items, calculating totals, and preparing the basket for checkout.

## Project

`src/Modules/Basket/Basket/Basket.csproj`

## Registration

```csharp
// Service registration
builder.Services.AddBasketModule(builder.Configuration);

// Middleware / endpoint registration
app.UseBasketModule();
```

## Configuration

```json
{
  "BasketModule": {
    "RedisConnection": "localhost:6379"
  }
}
```

## Planned Features

- [ ] Get basket by customer ID
- [ ] Add item to basket
- [ ] Update item quantity
- [ ] Remove item from basket
- [ ] Clear basket (e.g. after order is placed)

## Domain Concepts

| Concept | Description |
|---|---|
| `Basket` | A collection of items for a specific customer |
| `BasketItem` | A product reference with quantity and unit price |

## Endpoints

> _To be documented as endpoints are implemented._

## Cross-Module Events

| Event | Direction | Action |
|---|---|---|
| `OrderPlacedEvent` | Ordering → Basket | Clears the basket |

## Dependencies

- `Shared` — shared abstractions

