# Architecture Overview

## What is a Modulith?

A **Modulith** (Modular Monolith) is a single deployable application divided into strongly bounded, loosely coupled modules. It combines the simplicity of a monolith with the modularity discipline of microservices — without the distributed systems complexity.

```
┌─────────────────────────────────────────┐
│              ASP.NET Core Host          │
│  ┌──────────┐ ┌─────────┐ ┌──────────┐ │
│  │  Catalog │ │ Basket  │ │ Ordering │ │
│  │  Module  │ │ Module  │ │  Module  │ │
│  └──────────┘ └─────────┘ └──────────┘ │
│          ↓           ↓          ↓       │
│         ┌───────────────────────┐       │
│         │     Shared Kernel     │       │
│         └───────────────────────┘       │
└─────────────────────────────────────────┘
```

## Architectural Patterns Used

| Pattern | Purpose |
|---|---|
| **Modulith** | Bounded module isolation within a single process |
| **Vertical Slice Architecture (VSA)** | Features are organized by use-case, not technical layer |
| **Domain-Driven Design (DDD)** | Domain logic in aggregates, value objects, and bounded contexts |

## Project Dependency Rules

```
Api (Bootstrapper)
  └── Basket.csproj
  └── Catalog.csproj
  └── Ordering.csproj
        └── Shared.csproj  (referenced by all modules)
```

- Modules **do NOT** reference each other directly.
- All modules reference only `Shared` for common abstractions.
- `Api` is the composition root — it references all modules and wires them together.

## Module Boundaries

Each module is a separate `.csproj` class library. It exposes exactly two public contracts to the `Api` bootstrapper:

```csharp
// Registration
services.Add{Module}Module(configuration);

// Middleware pipeline
app.Use{Module}Module();
```

Everything else inside a module is internal to that module.

## Further Reading

- [Module Communication](module-communication.md)
- [ADR-001: Why Modulith?](../decisions/adr-001-modulith-pattern.md)

