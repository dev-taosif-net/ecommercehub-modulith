# Ordering Module

## Responsibility

The **Ordering** module manages the full order lifecycle — from order placement through fulfillment and status tracking.

## Project

`src/Modules/Ordering/Ordering/Ordering.csproj`

## Registration

```csharp
// Service registration
builder.Services.AddOrderingModule(builder.Configuration);

// Middleware / endpoint registration
app.UseOrderingModule();
```

## Configuration

```json
{
  "OrderingModule": {
    "ConnectionString": "..."
  }
}
```

## Planned Features

- [ ] Create order from basket
- [ ] Get order by ID
- [ ] List orders by customer
- [ ] Update order status
- [ ] Cancel order

## Domain Concepts

| Concept | Description |
|---|---|
| `Order` | The confirmed purchase by a customer |
| `OrderItem` | A line item in an order (product, quantity, price) |
| `OrderStatus` | Lifecycle state: Pending, Confirmed, Shipped, Delivered, Cancelled |

## Endpoints

> _To be documented as endpoints are implemented._

## Cross-Module Events

| Event | Direction | Action |
|---|---|---|
| `OrderPlacedEvent` | Ordering → Basket | Triggers basket clearance |

## Dependencies

- `Shared` — shared abstractions

