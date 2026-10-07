# Broadband Supplier Simulator

An API that allows the acurate simulation of replies to the TM Forum broadband ordering process. Is based on on the BTW interpretation of the TMP Forum OpenAPI specifications for Product Ordering, Appointment Management, Geographic Address and Product and Network Availability.

## Getting started

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```powershell
dotnet build BroadbandSupplierSimulator.slnx
dotnet run --project BroadbandSupplierSimulator --launch-profile http
```

The API listens on `http://localhost:5135` (or `https://localhost:7215` with the `https` profile). In the Development environment the OpenAPI document is served at `/openapi/v1.json`.

### Docker

Build with the repository root as the context:

```powershell
docker build -f BroadbandSupplierSimulator/Dockerfile -t broadband-supplier-simulator .
```

The container listens on ports 8080 (HTTP) and 8081 (HTTPS).

## Endpoints

| Controller | Method and route |
|---|---|
| ProductOrder | `POST /hubco/tmf/productOrderingManagement/v4/productOrder` |
| | `POST /hubco/tmf/productOrderingManagement/v4/productOrder/notification` |
| | `PATCH /hubco/tmf/productOrderingManagement/v4/productOrder/{id}` |
| | `POST /hubco/tmf/productOrderingManagement/v4/cancelProductOrder` |
| | `POST /hubco/tmf/productOrderingManagement/v4/cancelProductOrder/notification` |
| ProductInventory | `GET /tmf/productInventory/v4/product` |
| AppointmentManagement | `POST /common/appointmentManagement/v4/searchTimeSlot` |
| | `POST /common/appointmentManagement/v4/appointment` |
| GeographicAddress | `GET /common/geographicAddressManagement/v1/geographicAddress` |
| | `POST /common/geographicAddressManagement/v1/geographicAddress` |
| ProductAndNetworkAvailability | `POST /hubco/tmf/productOfferingQualification/v4/productOfferingQualification` |
| | `GET /v1/line-availability/line` |

Requests missing a required header (such as `APIGW-Tracking-Header`) or required body fields get a `400` response. Valid requests get the success status from the spec with an empty body.


## Simulating failures and delays

Every endpoint has two settings, configured under `Simulation:Endpoints:<EndpointName>`:

| Setting | Type | Default | Effect |
|---|---|---|---|
| `SendFailure` | bool | `false` | When `true`, the endpoint returns `500` with `{"code":"01","message":"Internal Error"}` |
| `ResponseDelayMs` | int | `0` | Milliseconds to wait before responding (also applies before a failure) |

Set them as environment variables using `__` as the separator, for example:

```powershell
$env:Simulation__Endpoints__CreateProductOrder__SendFailure = "true"
$env:Simulation__Endpoints__CreateProductOrder__ResponseDelayMs = "1500"
```

They can also be set in `appsettings.json`, which lists every endpoint with its defaults. The settings apply before request validation, so they take effect even for invalid requests.

| EndpointName | Route |
|---|---|
| `CreateProductOrder` | `POST .../productOrder` |
| `ProductOrderNotification` | `POST .../productOrder/notification` |
| `AmendProductOrder` | `PATCH .../productOrder/{id}` |
| `CancelProductOrder` | `POST .../cancelProductOrder` |
| `CancelProductOrderNotification` | `POST .../cancelProductOrder/notification` |
| `GetProduct` | `GET /tmf/productInventory/v4/product` |
| `SearchTimeSlot` | `POST .../searchTimeSlot` |
| `CreateAppointment` | `POST .../appointment` |
| `GetGeographicAddress` | `GET .../geographicAddress` |
| `CreateGeographicAddress` | `POST .../geographicAddress` |
| `CreateProductOfferingQualification` | `POST .../productOfferingQualification` |
| `GetAddressLineAvailability` | `GET /v1/line-availability/line` |

## Database connection

The Postgres connection string is not stored in the repository. It is read from the `ConnectionStrings:Hobby` setting.

For local development, store it as a user secret:

```powershell
dotnet user-secrets set "ConnectionStrings:Hobby" "Host=localhost;Port=5432;Database=hobby;Username=postgres;Password=<password>" --project BroadbandSupplierSimulator
```

In any other environment, set the `ConnectionStrings__Hobby` environment variable. The app fails at startup if the setting is missing. The same secret is used by the design-time factory when running `dotnet ef` commands.
