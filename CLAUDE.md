# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

BroadbandSupplierSimulator is an ASP.NET Core Web API (.NET 10, controller-based, nullable + implicit usings enabled) that simulates a broadband supplier's product order API. The solution file is `BroadbandSupplierSimulator.slnx` (new XML solution format) and contains:

- `BroadbandSupplierSimulator/` - the web API (controllers, services, validators, mappers, simulation helpers, Hangfire jobs).
- `BroadbandSupplierSimulator.Data/` - EF Core data layer (Postgres, generic repository, migrations, design-time `SimulatorDbContextFactory`).
- `BroadbandSupplierSimulatorTestProject/` - tests.

Creating a product order validates it, saves it via the generic repository, and enqueues a Hangfire job (`ProcessProductOrderJob`) that simulates order progression and sends state events.

## Commands

Run from the repo root:

- Build: `dotnet build BroadbandSupplierSimulator.slnx`
- Run (http://localhost:5135): `dotnet run --project BroadbandSupplierSimulator --launch-profile http`
- Run with HTTPS (https://localhost:7215): `--launch-profile https`
- Test: `dotnet test`; a single test with `dotnet test --filter "FullyQualifiedName~<TestName>"`
- Docker image: build with the repo root as context, since the Dockerfile copies `BroadbandSupplierSimulator/...` paths: `docker build -f BroadbandSupplierSimulator/Dockerfile -t broadband-supplier-simulator .`

## Postgres

- The app requires a Postgres connection string in `ConnectionStrings:Hobby` and throws at startup if it is missing. It is used for both EF Core and Hangfire storage.
- Locally, store it as a user secret (the project has a `UserSecretsId`):
  `dotnet user-secrets set "ConnectionStrings:Hobby" "Host=localhost;Port=5432;Database=hobby;Username=postgres;Password=<password>" --project BroadbandSupplierSimulator`
- Elsewhere (e.g. Docker), set the `ConnectionStrings__Hobby` environment variable.
- EF Core migrations live in `BroadbandSupplierSimulator.Data`. `dotnet-ef` is a local tool (`dotnet-tools.json`), so run `dotnet tool restore` first. `SimulatorDbContextFactory` reads the same user secret at design time.
  - Apply: `dotnet ef database update --project BroadbandSupplierSimulator.Data --startup-project BroadbandSupplierSimulator`
  - Add: `dotnet ef migrations add <Name> --project BroadbandSupplierSimulator.Data --startup-project BroadbandSupplierSimulator`

- On startup `Program.cs` applies pending migrations (`MigrateDatabaseAsync`, with retries), unless `Database:MigrateOnStartup` is `false`.
- `docker-compose.yml` at the repo root runs the app plus a `postgres:17` container (`docker compose up --build`); the app is on http://localhost:8080 and Postgres on localhost:5432.

## Hangfire

- Configured in `Program.cs` with PostgreSQL storage (`Hangfire.PostgreSql`) and an in-process server (`AddHangfireServer`), so jobs run inside the API process; breakpoints in `ProcessProductOrderJob` hit when debugging.
- The dashboard (`app.UseHangfireDashboard()`) is only enabled in Development, at `/hangfire`.
- Jobs are resolved from DI (`IProcessProductOrderJob` is registered scoped).

## Simulation settings

Failure and delay behaviour is configured under the `Simulation` section of `appsettings.json` (`SimulationOptions`): `StageReturnFailure`, `MessageGapMs`, `SendUrl`, and per-endpoint `Endpoints:<Name>` with `SendFailure` and `ResponseDelayMs` (plus `AppointmentAvailable` for `SearchTimeSlot`). Override with environment variables using double underscores, e.g. `Simulation__MessageGapMs=500` (the Docker launch profile does this). See README.md for details.

## Notes

- OpenAPI document is only mapped in the Development environment (`app.MapOpenApi()` in `Program.cs`), served at `/openapi/v1.json`.
- `BroadbandSupplierSimulator.http` holds sample requests for use with the VS/Rider HTTP client.
- Container profile listens on 8080 (HTTP) / 8081 (HTTPS) and runs as the non-root `$APP_UID` user.
