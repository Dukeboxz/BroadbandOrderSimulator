# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

BroadbandSupplierSimulator is an ASP.NET Core Web API (.NET 10, controller-based, nullable + implicit usings enabled). The solution file is `BroadbandSupplierSimulator.slnx` (new XML solution format); the single project lives in `BroadbandSupplierSimulator/`. It is currently the stock Visual Studio Web API template: `Program.cs` registers controllers and OpenAPI, and the only controller is the sample `WeatherForecastController`. No tests, no git repo yet, and no domain logic has been written.

## Commands

Run from the repo root:

- Build: `dotnet build BroadbandSupplierSimulator.slnx`
- Run (http://localhost:5135): `dotnet run --project BroadbandSupplierSimulator --launch-profile http`
- Run with HTTPS (https://localhost:7215): `--launch-profile https`
- Docker image: build with the repo root as context, since the Dockerfile copies `BroadbandSupplierSimulator/...` paths: `docker build -f BroadbandSupplierSimulator/Dockerfile -t broadband-supplier-simulator .`

There is no test project or lint config. If tests are added, run a single one with `dotnet test --filter "FullyQualifiedName~<TestName>"`.

## Notes

- OpenAPI document is only mapped in the Development environment (`app.MapOpenApi()` in `Program.cs`), served at `/openapi/v1.json`.
- `BroadbandSupplierSimulator.http` holds sample requests for use with the VS/Rider HTTP client.
- Container profile listens on 8080 (HTTP) / 8081 (HTTPS) and runs as the non-root `$APP_UID` user.
