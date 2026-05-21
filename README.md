# EcommerceHub Modulith

A modular monolith (Modulith) e-commerce backend built with **.NET 10**, following Vertical Slice Architecture (VSA) and Domain-Driven Design principles.

## Overview

EcommerceHub is structured as a **Modulith** — a single deployable unit composed of well-defined, loosely coupled modules. Each module owns its domain logic, and all modules communicate in-process through shared abstractions.

## Modules

| Module   | Responsibility               |
|----------|------------------------------|
| Catalog  | Products & categories        |
| Basket   | Shopping cart management     |
| Ordering | Order lifecycle & processing |

## Project Structure

```
src/
├── Bootstrapper/
│   └── Api/              → Entry point; composes all modules
├── Modules/
│   ├── Basket/           → Basket module
│   ├── Catalog/          → Catalog module
│   └── Ordering/         → Ordering module
└── Shared/
    └── Shared/           → Shared abstractions & contracts
docs/
├── architecture/         → Architecture decisions & diagrams
├── modules/              → Per-module documentation
├── shared/               → Shared kernel documentation
├── bootstrapper/         → API bootstrapper documentation
├── getting-started/      → Setup & running the application
└── decisions/            → Architecture Decision Records (ADRs)
```

## Quick Start

See [Getting Started](docs/getting-started/prerequisites.md) to get up and running.

## Documentation Index

### 🏗️ Architecture
- [Overview](docs/architecture/overview.md)
- [Module Communication](docs/architecture/module-communication.md)

### 🚀 Getting Started
- [Prerequisites](docs/getting-started/prerequisites.md)
- [Running Locally](docs/getting-started/running-locally.md)
- [Configuration](docs/getting-started/configuration.md)

### 📦 Modules
- [Catalog](docs/modules/catalog.md)
- [Basket](docs/modules/basket.md)
- [Ordering](docs/modules/ordering.md)

### 🔗 Shared
- [Shared Kernel](docs/shared/shared-kernel.md)

### ⚙️ Bootstrapper
- [API](docs/bootstrapper/api.md)

### 📋 Decisions (ADRs)
- [ADR-001: Modulith Pattern](docs/decisions/adr-001-modulith-pattern.md)

### 🐙 Git
- [Git Commands Reference](docs/git/git-commands-reference.md)

## Tech Stack

- [.NET 10](https://dotnet.microsoft.com/) / ASP.NET Core 10
- C# 14
- Modulith / Vertical Slice Architecture
