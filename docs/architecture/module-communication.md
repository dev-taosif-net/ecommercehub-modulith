# Module Communication

## In-Process Communication

Since EcommerceHub is a Modulith, all modules run **in the same process**. There is no HTTP, gRPC, or message broker between modules at this stage.

## Communication Patterns

### 1. Direct Method Call via Shared Interfaces

Modules expose interfaces in the `Shared` project. Other modules can resolve them via DI.

```
Module A → ISharedService (in Shared) ← Module B implements
```

### 2. Domain Events (recommended for cross-module side effects)

When a module needs to notify another module of something that happened, it publishes a **domain event**. The other module subscribes to it. This keeps modules fully decoupled.

```
Ordering Module  →  publishes: OrderPlacedEvent
Basket Module    ←  subscribes: clears the basket on OrderPlacedEvent
```

> Domain events are resolved in-process (e.g. via MediatR or a custom dispatcher).

## Rules

| Rule | Reason |
|---|---|
| Modules **must not** reference each other's `.csproj` | Prevents tight coupling |
| Cross-module contracts go in `Shared` | Single source of truth for shared types |
| Data stores should be **per-module** (separate schema/table prefix) | Enforces boundary at the data level |

## Current State

The modules currently have stub implementations. As features are added, communication will be introduced through:

1. `Shared` interfaces / contracts
2. In-process domain events

