# [Battlesnake](https://play.battlesnake.com) C# Starter

A Clean Architecture starter for [Battlesnake](https://play.battlesnake.com) written in C#, targeting **.NET 10**. Forked from [neistow/battlesnake-starter-csharp](https://github.com/neistow/battlesnake-starter-csharp).

## Technologies

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) (Minimal API)
- .NET 10
- xUnit

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Battlesnake Account](https://play.battlesnake.com)
- [Azure Account](https://azure.microsoft.com/en-us/) (for deployment)

## Architecture

Clean Architecture with four projects. Dependencies point inward only:

```
Battlesnake.Api  ──►  Battlesnake.Application  ──►  Battlesnake.Domain
     │                        ▲                            ▲
     └──►  Battlesnake.Infrastructure  ────────────────────┘
```

- **`Battlesnake.Domain`** — pure entities/value objects and enums; no external dependencies. The snake AI lives here: `Strategies/IMoveStrategy` + implementations. `SafeRandomMoveStrategy` (avoids walls and own body) is the registered default; `RandomMoveStrategy` is a purely random baseline.
- **`Battlesnake.Application`** — orchestration layer. `ISnakeService`/`SnakeService` handle the four lifecycle events. `SnakeOptions` holds the configurable appearance.
- **`Battlesnake.Infrastructure`** — adapters: `InMemoryGameStore` and `SnakeOptions` binding from `appsettings.json`.
- **`Battlesnake.Api`** — ASP.NET Core Minimal API and composition root. Maps the four Battlesnake endpoints.

## Running Locally

```bash
dotnet build                              # build the solution
dotnet test                               # run all unit tests
dotnet run --project src/Battlesnake.Api  # start the server (http://localhost:5000)
```

## Customising Your Snake

Edit `src/Battlesnake.Api/appsettings.json` to change the appearance:

```json
"Snake": {
  "color": "#888888",
  "head": "bee",
  "tail": "bee"
}
```

To change move behaviour, implement `IMoveStrategy` in `Battlesnake.Domain/Strategies/` and swap the registration in `src/Battlesnake.Domain/DependencyInjection.cs`.

## Deployment

The server exposes a plain HTTP API, so it can be hosted anywhere — Azure App Service, Fly.io, Railway, a VPS, or any other cloud provider. Publish the `Battlesnake.Api` project and point your Battlesnake to the resulting URL.
