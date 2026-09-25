# GestionLibreria — API REST de Gestión para Librería

API REST desarrollada en **.NET 10 / ASP.NET Core** para la gestión integral de una librería: clientes, empleados, productos y pedidos, aplicando **Clean Architecture** y principios de **Domain-Driven Design (DDD)**.

## Arquitectura

El proyecto está organizado en capas independientes, cada una en su propio proyecto de .NET, siguiendo el principio de inversión de dependencias:

```
GestionLibreria.Domain          → Entidades y reglas de negocio puras (sin dependencias externas)
GestionLibreria.Application     → Casos de uso, DTOs, interfaces de servicios
GestionLibreria.Infrastructure  → Persistencia (EF Core), implementación de repositorios
GestionLibreria.Presentation    → Controllers REST, configuración de la API
```

Esta separación permite que la lógica de negocio sea independiente del framework, la base de datos o la capa de presentación, facilitando testing y mantenimiento a largo plazo.

## Tecnologías

- **.NET 10 / ASP.NET Core** — Web API
- **Entity Framework Core 10** (SQL Server) — persistencia
- **Patrón Repository** — abstracción de acceso a datos vía interfaces (`IClientRepository`, `IOrderRepository`, etc.)
- **Inyección de Dependencias** nativa de ASP.NET Core
- **DTOs** — separación entre el modelo de dominio y los contratos de la API
- **OpenAPI / Swagger** — documentación de endpoints

## Modelo de dominio

- **User** (clase base abstracta) → **Client** y **Employee**
- **Product** — con categorías (`Book`, `Magazine`, `Stationery`, `Other`) y disponibilidad
- **Order** — con estados (`Pending`, `Paid`, `Cancelled`) y su colección de `OrderDetail`

La lógica de negocio vive en las entidades del dominio: por ejemplo, un `Order` solo puede marcarse como pagado o cancelado si está en estado `Pending`, y valida sus propias reglas (cantidades y precios positivos, IDs no vacíos) antes de aceptar cambios.

## Endpoints principales

| Recurso | Endpoints |
|---|---|
| **Clients** | CRUD de clientes |
| **Employees** | CRUD de empleados |
| **Products** | CRUD de productos |
| **Orders** | `POST /api/order` (crear), `GET /api/order`, `GET /api/order/{id}`, `PATCH /api/order/{id}/complete`, `PATCH /api/order/{id}/cancel` |
