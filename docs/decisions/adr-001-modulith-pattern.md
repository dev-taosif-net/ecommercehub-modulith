# ADR-001: Modulith Architectural Pattern

## Status

**Accepted**

## Date

2026-05-21

## Context

We need to build an e-commerce platform. The choices on the spectrum are:

1. **Traditional layered monolith** — simple to start, but becomes a "big ball of mud" over time; no clear boundaries.
2. **Microservices** — strong isolation, but introduces distributed systems complexity: networking, service discovery, distributed transactions, operational overhead.
3. **Modulith (Modular Monolith)** — a single deployable unit with enforced modular boundaries, combining simplicity of a monolith with the modularity discipline of microservices.

## Decision

We adopt the **Modulith** pattern.

Each business domain (Catalog, Basket, Ordering) is a self-contained module (separate `.csproj`) that:
- Owns its domain logic
- Exposes a minimal public API (`Add{Module}` / `Use{Module}`)
- Does not reference other modules directly
- Shares only contracts through the `Shared` kernel

## Consequences

### Positive

- ✅ Single deployment unit — no distributed systems complexity
- ✅ Strong module boundaries enforced at compile time (`.csproj` separation)
- ✅ Easy to reason about and develop locally (one app to run)
- ✅ Can evolve towards microservices later by extracting modules
- ✅ In-process communication — no network latency between modules

### Negative

- ⚠️ All modules scale together (no independent scaling per module)
- ⚠️ A bug in one module can crash the whole app (mitigated with resilience patterns)
- ⚠️ Requires discipline to respect module boundaries

## Alternatives Considered

| Alternative | Reason Rejected |
|---|---|
| Layered Monolith | No enforced boundaries, becomes tightly coupled over time |
| Microservices | Premature complexity for the current team size and scale |

## References

- [Microsoft eShop on dotnet (Modulith)](https://github.com/dotnet/eShop)
- [Modular Monolith by Kamil Grzybek](https://www.kamilgrzybek.com/design/modular-monolith-primer/)

